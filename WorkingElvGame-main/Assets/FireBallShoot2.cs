using UnityEngine;
using System.Collections;

public class FireBallShoot2 : MonoBehaviour
{
    public GameObject fireballPrefab; // Assign the fireball prefab in the Inspector
    public Transform firePoint; // Set a fire point (position where the fireball spawns)
    public float fireballSpeed = 10f;
    public float cooldownTime = 5f; // 5 seconds cooldown
    private bool canShoot = true; // Tracks whether Player 2 can shoot
    public Animator Player2Animator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && canShoot) // Change keybind for Player 2
        {
            ShootFireball();
        }
    }

    void ShootFireball()
    {
        if (fireballPrefab != null && firePoint != null)
        {
            GameObject fireball = Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = fireball.GetComponent<Rigidbody>();
            Player2Animator.SetTrigger("FireShoot");
            if (rb != null)
            {
                rb.useGravity = false; // Ensure gravity is disabled
                rb.AddForce(firePoint.forward * fireballSpeed, ForceMode.Impulse); // Apply force
            }

            StartCoroutine(FireballCooldown()); // Start cooldown timer

        }
    }

    IEnumerator FireballCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(cooldownTime);
        canShoot = true;
    }
}