using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player2Health : MonoBehaviour
{
    public Slider healthSlider;
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthSlider.value = currentHealth;

        if (currentHealth == 0)
        {
            // Load the "Player1Win" scene when Player2Health reaches 0
            SceneManager.LoadScene("Player1Win");
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthSlider.value = currentHealth;
    }
}
