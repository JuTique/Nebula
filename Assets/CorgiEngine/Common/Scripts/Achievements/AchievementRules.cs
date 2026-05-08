using UnityEngine;
using System.Collections;
using MoreMountains.Tools;
using UnityEngine.SceneManagement;

namespace MoreMountains.CorgiEngine
{
	/// <summary>
	/// This class describes how the Corgi Engine demo achievements are triggered.
	/// It extends the base class MMAchievementRules
	/// It listens for different event types
	/// </summary>
	public class AchievementRules : MMAchievementRules, 
		MMEventListener<MMGameEvent>, 
		MMEventListener<MMCharacterEvent>, 
		MMEventListener<CorgiEngineEvent>,
		MMEventListener<MMStateChangeEvent<CharacterStates.MovementStates>>,
		MMEventListener<MMStateChangeEvent<CharacterStates.CharacterConditions>>,
		MMEventListener<PickableItemEvent>,
		MMEventListener<MMSceneLoadingManager.LoadingSceneEvent>
	{
		protected static AchievementRules _instance;

		/// <summary>
		/// Ensures an AchievementRules instance exists early in the app lifecycle.
		/// </summary>
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		protected static void InitializeInstance()
		{
			if (FindObjectOfType<AchievementRules>() == null)
			{
				GameObject go = new GameObject("AchievementRules");
				go.AddComponent<AchievementRules>();
				DontDestroyOnLoad(go);
				Debug.Log("[AchievementRules] Auto-created AchievementRules instance before scene load.");
			}
		}

		protected int _coinsInCurrentLevel;
		protected int _coinsCollectedInCurrentLevel;
		protected bool _ahorradorUnlockedThisLevel;
		protected bool _atrapadoUnlocked;

		protected virtual void InitializeLevelCoinState()
		{
			_coinsInCurrentLevel = 0;
			_coinsCollectedInCurrentLevel = 0;
			_ahorradorUnlockedThisLevel = false;

			Coin[] coins = FindObjectsByType<Coin>(FindObjectsSortMode.None);
			_coinsInCurrentLevel = (coins != null) ? coins.Length : 0;
		}

		/// <summary>
		/// Unlocks an achievement and ensures it's saved and the UI refreshed.
		/// </summary>
		protected virtual void UnlockAndRefresh(string achievementID)
		{
			MMAchievementManager.UnlockAchievement(achievementID);
			MMAchievementManager.SaveAchievements();
			MMAchievementManager.LoadSavedAchievements();
			MMAchievementManager.LoadAchievementList(MMAchievementList.Any);
			MMAchievementManager.LoadSavedAchievements();
			MMAchievementManager.LoadAchievementList(MMAchievementList.Any);
			Debug.Log($"[AchievementRules] Called UnlockAndRefresh for {achievementID}");
			MMAchievementManager.LoadSavedAchievements();
			// print status for debugging
			if (this.PrintCurrentStatusBtn)
			{
				PrintCurrentStatus();
			}
		}

		/// <summary>
		/// When we catch an MMGameEvent, we do stuff based on its name
		/// </summary>
		/// <param name="gameEvent">Game event.</param>
		public override void OnMMEvent(MMGameEvent gameEvent)
		{
			base.OnMMEvent (gameEvent);

		}

		public virtual void OnMMEvent(MMCharacterEvent characterEvent)
		{
			if (characterEvent.TargetCharacter.CharacterType == Character.CharacterTypes.Player)
			{
				// unlock Atrapadoen_Titán when the player starts moving in Nivel1
				if (!_atrapadoUnlocked && SceneManager.GetActiveScene().name == "Nivel1")
				{
					if (characterEvent.EventType == MMCharacterEventTypes.Run && characterEvent.Moment == MMCharacterEvent.Moments.Start)
					{
						Debug.Log("[AchievementRules] Player started running in Nivel1 — unlocking Atrapadoen_Titán");
						UnlockAndRefresh("Atrapadoen_Titán");
						_atrapadoUnlocked = true;
					}
				}
				// existing example: track jumps
				switch (characterEvent.EventType)
				{
					case MMCharacterEventTypes.Jump:
						MMAchievementManager.AddProgress ("JumpAround", 1);
						break;
				}
			}
		}

		public virtual void OnMMEvent(CorgiEngineEvent corgiEngineEvent)
		{
			switch (corgiEngineEvent.EventType)
			{
				case CorgiEngineEventTypes.LevelStart:
					InitializeLevelCoinState();
					break;
				case CorgiEngineEventTypes.LevelEnd:
					UnlockAndRefresh("PrincessInAnotherCastle");
					break;
				case CorgiEngineEventTypes.PlayerDeath:
					UnlockAndRefresh("DeathIsOnlyTheBeginning");
					break;
			}
		}

		public virtual void OnMMEvent(PickableItemEvent pickableItemEvent)
		{
			if (pickableItemEvent.PickedItem != null)
			{
				if (pickableItemEvent.PickedItem.GetComponent<Coin>() != null)
				{
					if (!_ahorradorUnlockedThisLevel)
					{
						_coinsCollectedInCurrentLevel++;
						if ((_coinsInCurrentLevel > 0) && (_coinsCollectedInCurrentLevel >= _coinsInCurrentLevel))
						{
							_ahorradorUnlockedThisLevel = true;
							UnlockAndRefresh("Ahorrador");
						}
					}
				}
				if (pickableItemEvent.PickedItem.GetComponent<Stimpack>() != null)
				{
					UnlockAndRefresh("Medic");
				}
			}
		}

		/// <summary>
		/// When a scene starts loading via MMSceneLoadingManager, unlock specific achievements.
		/// </summary>
		/// <param name="loadingEvent"></param>
		public virtual void OnMMEvent(MMSceneLoadingManager.LoadingSceneEvent loadingEvent)
		{
			Debug.Log($"[AchievementRules] Received LoadingSceneEvent: SceneName={loadingEvent.SceneName}, Status={loadingEvent.Status}");
			if (!string.IsNullOrEmpty(loadingEvent.SceneName))
			{
				if ((loadingEvent.SceneName == "Nivel1") && (loadingEvent.Status == MMSceneLoadingManager.LoadingStatus.LoadStarted))
				{
					Debug.Log("[AchievementRules] Unlocking Atrapadoen_Titán on LoadingSceneEvent.LoadStarted for Nivel1");
						UnlockAndRefresh("Atrapadoen_Titán");
				}
			}
		}

		/// <summary>
		/// Helper stub: call this from enemy death logic when an enemy of a given type is killed.
		/// Example: EnemyHealth.OnDeath() -> AchievementRules.Instance.RegisterEnemyKill("Nebular");
		/// </summary>
		public virtual void RegisterEnemyKill(string enemyType)
		{
			
			if (enemyType == "Nebular")
			{
				MMAchievementManager.AddProgress("Cazador_nebular", 1);
			}
		}

		/// <summary>
		/// Helper stub: call this when the player uses a block to access a secret area.
		/// </summary>
		public virtual void RegisterSecretAreaAccess()
		{
			UnlockAndRefresh("Ingeniero_improvisado");
		}

		/// <summary>
		/// Helper stub: call this when a boss dies. Use bossId to map to achievements.
		/// </summary>
		public virtual void RegisterBossDeath(string bossId)
		{
			if (bossId == "CentinelaCorroido")
			{
				UnlockAndRefresh("Chatarra_viviente");
			}
			if (bossId == "EspectroReactor")
			{
				UnlockAndRefresh("Wubba_Lubba_Dub_Dub");
			}
		}

		public virtual void OnMMEvent(MMStateChangeEvent<CharacterStates.MovementStates> movementEvent)
		{
			/*switch (movementEvent.NewState)
			{

			}*/
		}

		public virtual void OnMMEvent(MMStateChangeEvent<CharacterStates.CharacterConditions> conditionEvent)
		{
			/*switch (conditionEvent.NewState)
			{

			}*/
		}

		/// <summary>
		/// On enable, we start listening for MMGameEvents. You may want to extend that to listen to other types of events.
		/// </summary>
		protected override void OnEnable()
		{
			base.OnEnable ();
			this.MMEventStartListening<MMCharacterEvent>();
			this.MMEventStartListening<CorgiEngineEvent>();
			this.MMEventStartListening<MMStateChangeEvent<CharacterStates.MovementStates>>();
			this.MMEventStartListening<MMStateChangeEvent<CharacterStates.CharacterConditions>>();
			this.MMEventStartListening<PickableItemEvent>();
			this.MMEventStartListening<MMSceneLoadingManager.LoadingSceneEvent>();

			// also listen to Unity sceneLoaded to catch cases where AchievementRules
			// wasn't present when the MMSceneLoadingManager.LoadingSceneEvent fired
			SceneManager.sceneLoaded += OnSceneLoaded;

			// if we're already in Nivel1 when enabled, unlock immediately
			if (SceneManager.GetActiveScene().name == "Nivel1")
			{
				UnlockAndRefresh("Atrapadoen_Titán");
			}
		}

		/// <summary>
		/// On disable, we stop listening for MMGameEvents. You may want to extend that to stop listening to other types of events.
		/// </summary>
		protected override void OnDisable()
		{
			base.OnDisable ();
			this.MMEventStopListening<MMCharacterEvent>();
			this.MMEventStopListening<CorgiEngineEvent>();
			this.MMEventStopListening<MMStateChangeEvent<CharacterStates.MovementStates>>();
			this.MMEventStopListening<MMStateChangeEvent<CharacterStates.CharacterConditions>>();
			this.MMEventStopListening<PickableItemEvent>();
			this.MMEventStopListening<MMSceneLoadingManager.LoadingSceneEvent>();

			SceneManager.sceneLoaded -= OnSceneLoaded;
		}

		/// <summary>
		/// Unity sceneLoaded callback: unlock when Nivel1 finishes loading
		/// </summary>
		protected virtual void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
			Debug.Log($"[AchievementRules] OnSceneLoaded: {scene.name}");
			if (scene.name == "Nivel1")
			{
				Debug.Log("[AchievementRules] Unlocking Atrapadoen_Titán on SceneManager.sceneLoaded for Nivel1");
				UnlockAndRefresh("Atrapadoen_Titán");
			}
		}
	}
}