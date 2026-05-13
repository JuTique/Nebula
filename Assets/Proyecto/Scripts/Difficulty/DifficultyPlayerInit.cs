using UnityEngine;
using MoreMountains.CorgiEngine;

public class DifficultyPlayerInit : MonoBehaviour
{
    void Start()
    {
        Character player = GetComponent<Character>();
        if (player != null)
        {
            Health playerHealth = player.GetComponent<Health>();
            if (playerHealth != null)
            {
                int maxHealth = DifficultyManager.GetPlayerHealth();
                playerHealth.MaximumHealth = maxHealth;
                playerHealth.CurrentHealth = maxHealth;
                Debug.Log($"Vida del jugador configurada a: {maxHealth}");
            }
        }
    }
}
