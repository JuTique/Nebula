using UnityEngine;
using MoreMountains.CorgiEngine;

public class DifficultyDamageScaler : MonoBehaviour
{
    void Start()
    {
        int enemyDamage = DifficultyManager.GetEnemyDamage();

        // Buscar y modificar DamageOnTouch (para enemigos que atacan tocando)
        DamageOnTouch[] damageOnTouches = GetComponentsInChildren<DamageOnTouch>();
        foreach(var dot in damageOnTouches)
        {
            dot.MinDamageCaused = enemyDamage;
            dot.MaxDamageCaused = enemyDamage;
            Debug.Log($"DamageOnTouch modificado a: {enemyDamage}");
        }
    }
}
