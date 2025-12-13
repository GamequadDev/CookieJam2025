using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int damage;
    public Entity.EntityType shooterType;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Arrow hit: " + other.gameObject.name);
        Entity entity = other.GetComponent<Entity>();
        if (entity != null)
        {
            entity.TakeDamage(damage, shooterType);
        }
    }
}
