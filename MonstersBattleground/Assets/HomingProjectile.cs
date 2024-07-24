using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectile : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 3f;
    private GameObject target;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody found on the projectile.");
            Destroy(gameObject);
            return;
        }

        // Start the coroutine to destroy the projectile after a set lifetime
        StartCoroutine(SelfDestructAfterLifetime());
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            // Calculate the direction towards the target
            Vector3 direction = (target.transform.position - transform.position).normalized;

            // Move the projectile towards the target
            rb.velocity = direction * speed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the projectile collided with the target player
        if (collision.gameObject == target)
        {
            // Deal damage to the player
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(10); // Adjust damage value as needed
            }
        }

        // Destroy the projectile on collision
        Destroy(gameObject);
    }

    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }

    IEnumerator SelfDestructAfterLifetime()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}