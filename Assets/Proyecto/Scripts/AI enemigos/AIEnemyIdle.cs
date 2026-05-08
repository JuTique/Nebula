using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.CorgiEngine;

namespace Proyecto.AIEnemigos
{
	[AddComponentMenu("Proyecto/AI Enemigos/AI Enemy Idle")]
	public class AIEnemyIdle : AIAction
	{
		[Tooltip("If true, the enemy will face the target while idling")]
		public bool FaceTarget = true;

		protected Character _character;
		protected CharacterHorizontalMovement _horizontalMovement;

		public override void Initialization()
		{
			if (!ShouldInitialize)
			{
				return;
			}

			_character = GetComponentInParent<Character>();
			_horizontalMovement = _character?.FindAbility<CharacterHorizontalMovement>();
		}

		public override void PerformAction()
		{
			_horizontalMovement?.SetHorizontalMove(0f);

			if (!FaceTarget || _character == null || _brain.Target == null)
			{
				return;
			}

			_character.Face(_brain.Target.position.x >= transform.position.x
				? Character.FacingDirections.Right
				: Character.FacingDirections.Left);
		}

		public override void OnEnterState()
		{
			base.OnEnterState();
			_horizontalMovement?.SetHorizontalMove(0f);
		}

		public override void OnExitState()
		{
			base.OnExitState();
			_horizontalMovement?.SetHorizontalMove(0f);
		}
	}
}