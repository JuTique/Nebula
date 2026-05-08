using UnityEngine;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;

namespace Proyecto.AIEnemigos
{
	[AddComponentMenu("Proyecto/AI Enemigos/AI Enemy Decision In Attack Range")]
	public class AIEnemyDecisionInAttackRange : AIDecisionDistanceToTarget
	{
		public override void Initialization()
		{
			base.Initialization();
			ComparisonMode = ComparisonModes.LowerThan;
			Distance = 6f;
		}
	}
}