using UnityEngine;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;

namespace Proyecto.AIEnemigos
{
	[AddComponentMenu("Proyecto/AI Enemigos/AI Enemy Decision Time In State")]
	public class AIEnemyDecisionTimeInState : AIDecisionTimeInState
	{
		public override void Initialization()
		{
			base.Initialization();
			AfterTimeMin = 1.5f;
			AfterTimeMax = 3f;
		}
	}
}