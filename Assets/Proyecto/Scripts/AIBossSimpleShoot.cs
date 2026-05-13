using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.CorgiEngine;

public class AIBossSimpleShoot : AIAction
{
    [Header("Disparo Simple")]
    public GameObject ProjectilePrefab; // El prefab de algo que quieras disparar (ej: una bola de fuego)
    public Transform FirePoint; // De dónde sale el disparo (puede ser el jefe mismo)
    public float TimeBetweenShots = 1f;

    private float _lastShootTime;

    public override void PerformAction()
    {
        if (Time.time - _lastShootTime >= TimeBetweenShots)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (ProjectilePrefab == null || FirePoint == null || _brain.Target == null) return;

        // Instancia el proyectil
        GameObject projectile = Instantiate(ProjectilePrefab, FirePoint.position, Quaternion.identity);

        // Calcula dirección hacia el jugador
        Vector2 direction = (_brain.Target.position - FirePoint.position).normalized;

        // Si el proyectil tiene RigidBody (física), empújalo
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * 10f; // Velocidad del proyectil
        }
        // Si no, le puedes poner un script simple de "MoverHaciaAdelante", o CorgiProjectile si lo tiene.

        // Destruir el proyectil después de 3 segundos para que no llene la memoria
        Destroy(projectile, 3f);

        _lastShootTime = Time.time;
    }
}
