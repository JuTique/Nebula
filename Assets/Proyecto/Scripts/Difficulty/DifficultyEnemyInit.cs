using UnityEngine;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;

public class DifficultyEnemyInit : MonoBehaviour
{
    void Start()
    {
        // Aplicar daño de enemigos
        Health enemyHealth = GetComponent<Health>();
        if (enemyHealth != null)
        {
            // El daño se aplica al atacar, no a la salud
            // Usamos DamageFeedbacks para esto
        }

        // Aplicar agresión de IA
        AIBrain aiBrain = GetComponent<AIBrain>();
        if (aiBrain != null)
        {
            float aggression = DifficultyManager.GetEnemyAggression();
            
            // Aumentar velocidad de movimiento según agresión
            CharacterHorizontalMovement movement = GetComponent<CharacterHorizontalMovement>();
            if (movement != null)
            {
                movement.MovementSpeed *= aggression;
                movement.WalkSpeed *= aggression;
                Debug.Log($"Velocidad de enemigo ajustada a: {movement.MovementSpeed}");
            }
        }
    }
}
