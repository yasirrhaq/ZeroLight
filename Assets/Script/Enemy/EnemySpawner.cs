using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnDelay;

    public int enemyCount;
    public int enemySpawned;

    public Transform[] spawnPos;
    public GameObject enemy;

    IEnumerator RandomGenerate(float wait)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            int random = Random.Range(0, spawnPos.Length);
            if (spawnPos[random].childCount <1 && enemySpawned <= enemyCount)
            {
                enemy = Instantiate(enemy, spawnPos[random].position, Quaternion.identity);
                enemy.transform.SetParent(spawnPos[random]);
                enemySpawned++;
                yield return new WaitForSeconds(wait);
            }
            else
            {
                i--;
            }
        }
    }

    void Start()
    {
        StartCoroutine(RandomGenerate(spawnDelay));
    }
}
