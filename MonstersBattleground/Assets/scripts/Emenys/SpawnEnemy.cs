using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyPrefabs; // Array de prefabs de inimigos
    [SerializeField] private int numberOfEnemies; // Número de inimigos a serem gerados

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                float randomX = Random.Range(-23f, 23f);
                float randomZ = Random.Range(10.8f, 24f);
                Vector3 spawnPosition = new Vector3(randomX, 0, randomZ);

                int randomIndex = Random.Range(0, _enemyPrefabs.Length);
                GameObject randomEnemyPrefab = _enemyPrefabs[randomIndex];

                Instantiate(randomEnemyPrefab, spawnPosition, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}

