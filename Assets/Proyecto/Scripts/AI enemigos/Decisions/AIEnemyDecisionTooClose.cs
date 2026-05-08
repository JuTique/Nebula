using UnityEngine;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;

namespace Proyecto.AIEnemigos
{
	[AddComponentMenu("Proyecto/AI Enemigos/AI Enemy Decision Too Close")]
	public class AIEnemyDecisionTooClose : AIDecisionDistanceToTarget
	{
		public override void Initialization()
		{
			base.Initialization();
			ComparisonMode = ComparisonModes.StrictlyLowerThan;
			Distance = 2f;
		}
	}
}