using UnityEngine;

public class Entity : MonoBehaviour
{
    public enum EntityType
    {
        Player,
        EnemyNPC,
        FriendlyNPC
    }
    public EntityType type;

    public int maxHealth;
    public int health;
    public int attackPower;
    public int defense;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Die();
        }
    }

    void TakeDamage(int damage, EntityType attackerType)
    {
        if (attackerType == EntityType.EnemyNPC && type == EntityType.FriendlyNPC || type == EntityType.Player)
        {
            int damageTaken = damage - defense;
            if (damageTaken < 0)
            {
                damageTaken = 0;
            }
            health -= damageTaken;
        }

        if (type == EntityType.EnemyNPC && attackerType == EntityType.FriendlyNPC || attackerType == EntityType.Player)
        {
            int damageTaken = damage - defense;
            if (damageTaken < 0)
            {
                damageTaken = 0;
            }
            health -= damageTaken;
        }
    }

    void Heal(int amount)
    {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    void Die()
    {
        if (type == EntityType.Player)
        {
            Debug.Log("Player has died. Game Over.");
            // Implement game over logic here
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
