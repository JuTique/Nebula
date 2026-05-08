using UnityEngine;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;

namespace Proyecto.AIEnemigos
{
	/// <summary>
	/// AI Attack action that deals damage via DamageOnTouch (melee), no weapon needed
	/// </summary>
	[AddComponentMenu("Proyecto/AI Enemigos/AI Enemy Attack")]
	public class AIEnemyAttack : AIAction
	{
		[Header("Attack Settings")]
		/// the damage component (DamageOnTouch) that will deal damage
		[Tooltip("the damage component (DamageOnTouch) that will deal damage")]
		public DamageOnTouch DamageOnTouch;
		/// whether to face the target while attacking
		[Tooltip("whether to face the target while attacking")]
		public bool FaceTarget = true;
		/// duration of the attack in seconds
		[Tooltip("duration of the attack in seconds")]
		public float AttackDuration = 0.5f;

		protected float _attackTimer = 0f;
		protected Character _character;
		protected bool _isAttacking = false;

		public override void Initialization()
		{
			_character = GetComponentInParent<Character>();
			if (DamageOnTouch == null)
			{
				DamageOnTouch = GetComponentInParent<DamageOnTouch>();
			}
			if (DamageOnTouch == null)
			{
				Debug.LogWarning("AIEnemyAttack: No DamageOnTouch found on " + gameObject.name);
			}
		}

		public override void PerformAction()
		{
			if (!_isAttacking)
			{
				StartAttack();
			}
			UpdateAttack();
		}

		protected virtual void StartAttack()
		{
			if (FaceTarget && _brain.Target != null && _character != null)
			{
				if (transform.position.x > _brain.Target.position.x)
				{
					_character.Face(Character.FacingDirections.Left);
				}
				else
				{
					_character.Face(Character.FacingDirections.Right);
				}
			}
			_attackTimer = 0f;
			_isAttacking = true;
			Debug.Log("AIEnemyAttack: Starting attack on " + gameObject.name);
		}

		protected virtual void UpdateAttack()
		{
			if (!_isAttacking)
			{
				return;
			}
			_attackTimer += Time.deltaTime;
			if (_attackTimer >= AttackDuration)
			{
				_isAttacking = false;
			}
		}

		public override void OnEnterState()
		{
			base.OnEnterState();
			_isAttacking = false;
			_attackTimer = 0f;
		}

		public override void OnExitState()
		{
			base.OnExitState();
			_isAttacking = false;
		}
	}
}