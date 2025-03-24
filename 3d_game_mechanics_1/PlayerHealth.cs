using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 150f;
    private float currentHealth;
    
    public Image healthBarFill; // Reference to the UI health bar

    private bool isHealing = false;
    private Coroutine healingCoroutine;
    private float healDelay = 6f; // Time before healing starts
    private float healRate = 0.03f; // Time per healing tick
    private float healAmountPerTick = 1f; // HP restored per tick

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
            return;
        }

        // Stop healing if taking damage
        if (healingCoroutine != null)
        {
            StopCoroutine(healingCoroutine);
        }
        isHealing = false;

        // Start healing delay
        healingCoroutine = StartCoroutine(DelayedHeal());
    }

    private IEnumerator DelayedHeal()
    {
        yield return new WaitForSeconds(healDelay); // Wait before healing starts
        isHealing = true;

        while (isHealing && currentHealth < maxHealth)
        {
            currentHealth += healAmountPerTick;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            UpdateHealthUI();
            yield return new WaitForSeconds(healRate);
        }

        isHealing = false;
    }

    void UpdateHealthUI()
    {
        healthBarFill.fillAmount = currentHealth / maxHealth;
    }

    private bool isDead = false; // Prevent multiple death calls
    void Die()
    {
        if (isDead) return;
        isDead = true;

        Debug.Log("Player Died!");
        FindAnyObjectByType<RespawnManager>().PlayerDied(transform);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) // Press "H" to take damage (for testing)
        {
            TakeDamage(10);
        }
    }

    public void HealInstantly(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();
    }
}
