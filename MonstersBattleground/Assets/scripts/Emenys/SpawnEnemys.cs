using UnityEngine;

public class SpawnEnemiesOnCollision : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs; // Array de diferentes inimigos
    [SerializeField] private float minX; // Posi��o m�nima em X
    [SerializeField] private float maxX; // Posi��o m�xima em X
    [SerializeField] private float minZ; // Posi��o m�nima em Z
    [SerializeField] private float maxZ; // Posi��o m�xima em Z

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
            0f, // Defina a coordenada Y como 0 para que os inimigos sejam spawnados no ch�o
            Random.Range(minZ, maxZ)
        );

        GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        Instantiate(randomEnemyPrefab, spawnPosition, Quaternion.identity);
    }
}
