using UnityEngine;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;

namespace Proyecto.AIEnemigos
{
	[AddComponentMenu("Proyecto/AI Enemigos/AI Enemy Decision Low Health")]
	public class AIEnemyDecisionLowHealth : AIDecisionHealth
	{
		public override void Initialization()
		{
			base.Initialization();
			TrueIfHealthIs = ComparisonModes.StrictlyLowerThan;
			HealthValue = 10;
			OnlyOnce = false;
		}
	}
}