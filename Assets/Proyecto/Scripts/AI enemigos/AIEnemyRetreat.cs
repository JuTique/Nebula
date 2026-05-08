using UnityEngine;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;

namespace Proyecto.AIEnemigos
{
	[AddComponentMenu("Proyecto/AI Enemigos/AI Enemy Retreat")]
	public class AIEnemyRetreat : AIActionMoveAwayFromTarget
	{
		public override void Initialization()
		{
			base.Initialization();
			MinimumDistance = 3f;
		}
	}
}