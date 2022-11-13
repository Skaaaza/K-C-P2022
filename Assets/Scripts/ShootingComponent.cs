using System;
using UnityEngine;

public class ShootingComponent : MonoBehaviour
{
    [SerializeField]
    private Projectile projectile;

    private Vector2 direction;
    
    private void Start()
    {
        PlayerMovement.OnDirectionChange += SetCurrentDirection;
    }

    private void OnDestroy()
    {
        PlayerMovement.OnDirectionChange -= SetCurrentDirection;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootProjectile();
        }
    }

    private void ShootProjectile()
    {
        Projectile newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
        newProjectile.transform.position = transform.position;
        newProjectile.Rigidbody.velocity = Vector2.zero;
        newProjectile.Rigidbody.velocity = direction * newProjectile.ProjectileSpeed;
    }

    private void SetCurrentDirection(Vector2 direction)
    {
        this.direction = direction;
    }
}
