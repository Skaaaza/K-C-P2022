using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField]
    private int maxHP = 100;

    private int currentHP;

    
    private void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damageAmount)
    {
        if (currentHP <= 0)
        {
            return;
        }
        
        currentHP -= damageAmount;

        if (currentHP <= 0)
        {
            ProcessDeath();
        }
    }

    public void ProcessDeath()
    {
        Debug.Log("You died :(");
    }
}
