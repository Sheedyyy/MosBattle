using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainProjectile : MonoBehaviour
{
    private GameObject impactIndicator;
    public int damage = 10; // Damage amount that the projectile will deal

    public void SetImpactIndicator(GameObject indicator)
    {
        impactIndicator = indicator;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the impact indicator
        if (collision.gameObject == impactIndicator)
        {
            Destroy(collision.gameObject); // Destroy the impact indicator
            Destroy(this.gameObject); // Destroy the rain projectile
        }

        // Check if the projectile collided with a player
        if (collision.gameObject.CompareTag("Player_1") || collision.gameObject.CompareTag("Player_2"))
        {
            // Deal damage to the player
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); // Adjust damage value as needed
            }
            // Destroy the projectile on collision
            Destroy(this.gameObject);
        }
    }
}