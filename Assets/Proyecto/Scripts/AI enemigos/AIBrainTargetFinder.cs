using UnityEngine;
using MoreMountains.Tools;

namespace Proyecto.AIEnemigos
{
	/// <summary>
	/// Este script busca al jugador y lo asigna como Target en el AIBrain
	/// </summary>
	public class AIBrainTargetFinder : MonoBehaviour
	{
		private AIBrain _aiBrain;
		private Transform _playerTransform;

		private void Start()
		{
			_aiBrain = GetComponent<AIBrain>();
			if (_aiBrain == null)
			{
				Debug.LogError("AIBrainTargetFinder: No AIBrain encontrado en " + gameObject.name);
				return;
			}

			StartCoroutine(FindPlayerRoutine());
		}

		private System.Collections.IEnumerator FindPlayerRoutine()
		{
			const float retryInterval = 0.5f;
			while (_playerTransform == null)
			{
				GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
				if (playerObject != null)
				{
					_playerTransform = playerObject.transform;
					_aiBrain.Target = _playerTransform;
					Debug.Log("AIBrainTargetFinder: Jugador asignado como Target en " + gameObject.name);

					// Log layer and collider info to help debug collision issues
					int playerLayer = playerObject.layer;
					string playerLayerName = LayerMask.LayerToName(playerLayer);
					Collider2D playerCollider2D = playerObject.GetComponent<Collider2D>();
					Collider playerCollider3D = playerObject.GetComponent<Collider>();
					Debug.LogFormat("AIBrainTargetFinder: Player layer={0} ({1}), Enemy layer={2} ({3})", playerLayer, playerLayerName, gameObject.layer, LayerMask.LayerToName(gameObject.layer));
					if (playerCollider2D == null && playerCollider3D == null)
					{
						Debug.LogWarning("AIBrainTargetFinder: El jugador no tiene Collider2D ni Collider3D. La colisión no funcionará si falta.");
					}
					else if (playerCollider2D != null)
					{
						Debug.Log("AIBrainTargetFinder: Player tiene Collider2D, isTrigger=" + playerCollider2D.isTrigger);
					}
					else
					{
						Debug.Log("AIBrainTargetFinder: Player tiene Collider3D, enabled=" + playerCollider3D.enabled);
					}
					yield break;
				}
				Debug.Log("AIBrainTargetFinder: Jugador no encontrado todavía, reintentando...");
				yield return new WaitForSeconds(retryInterval);
			}
		}
	}
}
