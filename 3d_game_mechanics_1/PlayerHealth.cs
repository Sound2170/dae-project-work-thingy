using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
   public float maxHealth = 100f;
    private float currentHealth;
    
    public Image healthBarFill; // Reference to the UI health bar

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthUI()
    {
        healthBarFill.fillAmount = currentHealth / maxHealth;
    }
    private bool isDead = false; // Prevent multiple death calls
    void Die()
    {
        if (isDead) return; // Prevents repeated death execution
    isDead = true;

    Debug.Log("Player Died!");
    FindAnyObjectByType<RespawnManager>().PlayerDied(transform);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) //press "H" to take damage
        {
            TakeDamage(10);
        }
    }
}
