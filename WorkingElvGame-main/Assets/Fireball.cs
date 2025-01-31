using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float lifetime = 3f; // Fireball lasts for 3 seconds
    public int damageAmount = 20; // Optional: Damage dealt to Player2

    void Start()
    {
        Destroy(gameObject, lifetime); // Destroy after 3 seconds if it doesn't hit anything
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player2")) // Check if it hits Player2
        {
            Destroy(gameObject); // Destroy fireball on impact

            // Optional: If Player2 has a health script, apply damage
            Player2Health player2Health = other.GetComponent<Player2Health>();
            if (player2Health != null)
            {
                player2Health.TakeDamage(damageAmount);
            }
        }
    }
}