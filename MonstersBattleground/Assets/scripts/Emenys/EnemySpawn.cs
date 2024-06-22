using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject inimigoPrefab;
    private int Xpos;
    private int Zpos;
    private int enemyCount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (enemyCount < 10)
        {
            Xpos = Random.Range(63, 102);
            Zpos = Random.Range(-245, -227);
            Instantiate(inimigoPrefab, new Vector3(Xpos, 3, Zpos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount++;
        }
    }
    
}
