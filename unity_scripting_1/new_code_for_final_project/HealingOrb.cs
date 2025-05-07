using UnityEngine;

public class HealingOrb : MonoBehaviour
{
    public float healAmount = 20f; //amount healed
    public float speed = 5f; //movement speed towards player

    private Transform target; // Player's position

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform; // Find player
    }

    void Update()
    {
        if (target != null)
        {
            // Move towards the player
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Heal the player
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.HealInstantly(healAmount);
            }

            // Destroy orb after healing
            Destroy(gameObject);
        }
    }

}
