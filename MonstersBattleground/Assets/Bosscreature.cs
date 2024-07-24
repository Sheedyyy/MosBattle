    using System.Collections;
    using System.Collections.Generic;
using UnityEngine;
    using UnityEngine.AI;
using static UnityEditor.Localization.LocalizationTableCollection;

    public class Bosscreature : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject projectilePrefab; // The projectile prefab to be fired
    public GameObject rainProjectilePrefab; // The projectile prefab for the rain attack
    public GameObject impactIndicatorPrefab; // The prefab to indicate impact points
    public Transform projectileParent; // The parent object for the projectiles
    public Transform firePoint; // The point from where the projectiles will be fired
    public Transform rainCenter; // The empty GameObject for the rain attack center
    private GameObject currentTarget;
    private float attackChangeInterval = 10f;
    private float projectileSpeed = 20f;
    private Coroutine changeAttackCoroutine;
    private Coroutine attackCoroutine;
    private int numProjectiles = 5; // Number of projectiles to fire in AttackPattern1
    private float projectileInterval = 1f; // Interval between projectiles

    // Rain of bullets parameters
    public float rainRadius = 10f;
    public int numRainProjectiles = 10;
    public float rainIntervalMin = 0.5f;
    public float rainIntervalMax = 1.5f;
    public float rainHeight = 10f; // Height from which the projectiles will fall

    // Define the different attack patterns as methods
    IEnumerator AttackPattern1()
    {
        if (currentTarget != null && projectileParent != null)
        {
            projectileParent.gameObject.SetActive(true);
            for (int i = 0; i < numProjectiles; i++)
            {
                FireProjectileAtTarget(currentTarget);
                yield return new WaitForSeconds(projectileInterval);
            }
            projectileParent.gameObject.SetActive(false); // Deactivate the parent after firing
        }
        else
        {
            Debug.LogError("Current target or projectile parent is null!");
        }
    }

    IEnumerator AttackPattern2()
    {
        for (int i = 0; i < numRainProjectiles; i++)
        {
            Vector3 randomPosition = GetRandomPositionWithinRadius();
            SpawnRainProjectileAtPosition(randomPosition);
            yield return new WaitForSeconds(Random.Range(rainIntervalMin, rainIntervalMax));
        }
    }

    void AttackPattern3() { /* Placeholder for Attack Pattern 3 */ }
    void AttackPattern4() { /* Placeholder for Attack Pattern 4 */ }
    void AttackPattern5() { /* Placeholder for Attack Pattern 5 */ }

    private delegate IEnumerator AttackPattern();
    private AttackPattern[] attackPatterns;

    private AttackPattern currentAttackPattern;

    void Start()
    {
        // Find players by their tags
        player1 = GameObject.FindGameObjectWithTag("Player_1");
        player2 = GameObject.FindGameObjectWithTag("Player_2");

        // Ensure players are found
        if (player1 == null || player2 == null)
        {
            Debug.LogError("Players not found. Make sure there are GameObjects with tags 'Player_1' and 'Player_2' in the scene.");
            return;
        }

        // Ensure projectile prefabs and fire point are assigned
        if (projectilePrefab == null || rainProjectilePrefab == null || firePoint == null)
        {
            Debug.LogError("Projectile prefabs or fire point are not assigned in the Inspector.");
            return;
        }

        // Initialize the array of attack patterns
        attackPatterns = new AttackPattern[] { AttackPattern1, AttackPattern2, };

        // Start the coroutine to change the attack pattern every 10 seconds
        changeAttackCoroutine = StartCoroutine(ChangeAttackPatternRoutine());
    }

    IEnumerator ChangeAttackPatternRoutine()
    {
        while (true)
        {
            ChangeAttackPattern();
            yield return new WaitForSeconds(attackChangeInterval);
        }
    }

    void ChangeAttackPattern()
    {
        // Stop the current attack coroutine if it's running
        if (attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
        }

        // Select a random attack pattern
        int randomIndex = Random.Range(0, attackPatterns.Length);
        currentAttackPattern = attackPatterns[randomIndex];
        Debug.Log("Changed to attack pattern: " + randomIndex);

        // Choose a random target between player1 and player2 for AttackPattern1
        if (currentAttackPattern == AttackPattern1)
        {
            currentTarget = Random.value < 0.5f ? player1 : player2;
            Debug.Log("Targeting: " + currentTarget.name);
        }

        // Start the selected attack pattern
        if (currentAttackPattern != null)
        {
            attackCoroutine = StartCoroutine(currentAttackPattern());
        }
    }

    void FireProjectileAtTarget(GameObject target)
    {
        if (firePoint == null)
        {
            Debug.LogError("Fire point is not assigned.");
            return;
        }

        // Instantiate the projectile at the fire point
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation, projectileParent);

        if (projectile == null)
        {
            Debug.LogError("Failed to instantiate projectile.");
            return;
        }

        // Log for debugging
        Debug.Log("Fired projectile at: " + target.name);

        // Set the target for the projectile
        HomingProjectile homingProjectile = projectile.GetComponent<HomingProjectile>();
        if (homingProjectile != null)
        {
            homingProjectile.SetTarget(target);
        }
        else
        {
            Debug.LogError("No HomingProjectile component found on the projectile prefab.");
        }
    }

    Vector3 GetRandomPositionWithinRadius()
    {
        if (rainCenter == null)
        {
            Debug.LogError("Rain center is not assigned.");
            return Vector3.zero;
        }

        Vector2 randomPos = Random.insideUnitCircle * rainRadius;
        Vector3 spawnPosition = new Vector3(rainCenter.position.x + randomPos.x, rainCenter.position.y + rainHeight, rainCenter.position.z + randomPos.y);
        return spawnPosition;
    }

    void SpawnRainProjectileAtPosition(Vector3 position)
    {
        // Instantiate the impact indicator at the specified position
        GameObject impactIndicator = Instantiate(impactIndicatorPrefab, new Vector3(position.x, rainCenter.position.y, position.z), Quaternion.identity);

        if (impactIndicator == null)
        {
            Debug.LogError("Failed to instantiate impact indicator.");
            return;
        }

        // Instantiate the projectile at the specified position
        GameObject projectile = Instantiate(rainProjectilePrefab, position, Quaternion.identity, projectileParent);

        if (projectile == null)
        {
            Debug.LogError("Failed to instantiate projectile.");
            return;
        }

        // Log for debugging
        Debug.Log("Spawned rain projectile at position: " + position);

        // Set the velocity of the projectile to simulate raining down
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.down * projectileSpeed;
            Debug.Log("Rain projectile velocity set to fall down: " + rb.velocity);
        }
        else
        {
            Debug.LogError("No Rigidbody found on the rain projectile prefab.");
        }

        // Destroy the projectile and the impact indicator on collision
        RainProjectile rainProjectile = projectile.GetComponent<RainProjectile>();
        if (rainProjectile != null)
        {
            rainProjectile.SetImpactIndicator(impactIndicator);
        }
    }

    void OnDrawGizmos()
    {
        if (rainCenter != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(rainCenter.position, rainRadius);
        }
    }
}