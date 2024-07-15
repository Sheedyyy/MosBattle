using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab; // Prefab do inimigo a ser gerado
    [SerializeField] private int numberOfEnemies; // Número de inimigos a serem gerados
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                float randomX = Random.Range(-23f, 23f);
                float randomZ = Random.Range(10.8f, 24f);
                Vector3 spawnPosition = new Vector3(randomX, transform.position.y, randomZ);
                Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}

