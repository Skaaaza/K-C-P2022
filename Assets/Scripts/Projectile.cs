using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] 
    private int damage;

    [SerializeField] 
    private float projectileSpeed;
    
    [SerializeField]
    private Rigidbody2D rigidbody;

    public Rigidbody2D Rigidbody => rigidbody;

    public float ProjectileSpeed => projectileSpeed;

    private void Start()
    {
        Destroy(gameObject,5f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var damageable = other.gameObject.GetComponent<IDamageable>();
        
        damageable?.TakeDamage(damage);
        Destroy(gameObject);
    }
}
