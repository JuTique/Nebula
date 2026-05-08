using UnityEngine;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;

namespace Proyecto.AIEnemigos
{
	[AddComponentMenu("Proyecto/AI Enemigos/AI Enemy Chase")]
	public class AIEnemyChase : AIActionMoveTowardsTarget
	{
		public override void Initialization()
		{
			base.Initialization();
			MinimumDistance = 1.25f;
		}
	}
}