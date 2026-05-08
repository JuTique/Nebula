using UnityEngine;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;

namespace Proyecto.AIEnemigos
{
	[AddComponentMenu("Proyecto/AI Enemigos/AI Enemy Patrol")]
	public class AIEnemyPatrol : AIActionPatrol
	{
		public override void Initialization()
		{
			base.Initialization();
			AvoidFalling = true;
			ChangeDirectionOnWall = true;
		}
	}
}