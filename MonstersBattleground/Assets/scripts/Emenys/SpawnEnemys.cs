using UnityEngine;

public class SpawnEnemiesOnCollision : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs; // Array de diferentes inimigos
    private float minX = -22f; // Posi��o m�nima em X
    private float maxX = 22f; // Posi��o m�xima em X
    private float minZ = 9f; // Posi��o m�nima em Z
    private float maxZ = 22f; // Posi��o m�xima em Z

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < 5; i++)
            {
                SpawnRandomEnemy();
                Destroy(gameObject);
            }
        }
    }

    private void SpawnRandomEnemy()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(minX, maxX),
            transform.position.y,
            Random.Range(minZ, maxZ)
        );

        GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        Instantiate(randomEnemyPrefab, spawnPosition, Quaternion.identity);
    }
}
