using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    [SerializeField] private int Xpos;
    [SerializeField] private int Zpos;
    [SerializeField] private int enemyCount;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (enemyCount < 10)
        {
            Xpos = Random.Range(63, 102);
            Zpos = Random.Range(-245,-227);
            Instantiate(Enemy, new Vector3(Xpos, 3, Zpos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }

    
}
