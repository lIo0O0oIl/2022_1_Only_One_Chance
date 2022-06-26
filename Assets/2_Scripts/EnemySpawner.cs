using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] StageData stageData;
    [SerializeField] float spawnTime;

    void Start()
    {
        StartCoroutine("SpawnEnemy");
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            float positionX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);
            Vector3 enemyPosition = new Vector3(positionX, stageData.LimitMax.y + 1f);
            Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);

            yield return new WaitForSeconds(spawnTime);
        }
    }
}
