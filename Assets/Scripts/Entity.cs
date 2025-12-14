using UnityEngine;
using UnityEngine.UI;

public class Entity : MonoBehaviour
{
    public Slider hpBar;

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
    public float attackTick = 0.5f;
    public float currentTick = 0f;
    public Collider2D collider2d;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(collider2d == null)
        {
            collider2d = GetComponent<Collider2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Die();
        }
        currentTick += Time.deltaTime;

        if (currentTick > attackTick)
        {
            // Reset trigger contacts by briefly disabling and enabling the collider
            if (collider2d != null)
            {
                collider2d.enabled = false;
                collider2d.enabled = true;
            }
        }

        if (hpBar != null)
        {
            hpBar.value = (float)health / maxHealth;
        }
    }

    public void TakeDamage(int damage, EntityType attackerType)
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

    public void Heal(int amount)
    {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public int goldReward = 1;

    void Die()
    {
        if (type == EntityType.Player)
        {
            Debug.Log("Player has died. Game Over.");
            // Implement game over logic here
        }
        else
        {
            if (type == EntityType.EnemyNPC)
            {
                GameManger gm = FindFirstObjectByType<GameManger>();
                if (gm != null)
                {
                    gm.AddCoins(goldReward);
                    Debug.Log($"Enemy died, awarded {goldReward} coins.");
                }
            }
            Destroy(gameObject);
        }
    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (currentTick > attackTick)
        {
            // start cooldown
            currentTick = 0f;
            Debug.Log("Entity hit: " + other.gameObject.name);
            Entity entity = other.GetComponent<Entity>();
            if (entity != null)
            {
                entity.TakeDamage(attackPower, type);
            }
        }
    }
}
