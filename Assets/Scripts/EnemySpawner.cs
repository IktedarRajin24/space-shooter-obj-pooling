using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private ObjectPooler enemyPool;
    [SerializeField] private int SpawnInterval;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnInterval);
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        GameObject enemy = enemyPool.GetPooledObject();
        enemy.transform.position = transform.position;
        enemy.SetActive(true);
    }
}
