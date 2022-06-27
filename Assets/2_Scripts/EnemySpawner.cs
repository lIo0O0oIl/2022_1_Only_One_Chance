using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] StageData stageData;
    [SerializeField] float spawnTime;

    [SerializeField] int maxEnemyCount = 150;
    [SerializeField] GameObject boss;
    Enemy enemy;

    void Awake()
    {
        enemy = GetComponent<Enemy>();
        boss.SetActive(false);
        StartCoroutine("SpawnEnemy");
    }

    IEnumerator SpawnEnemy()
    {
        int currentEnemyCount = 0;

        while (true)
        {
            float positionX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);
            Vector3 enemyPosition = new Vector3(positionX, stageData.LimitMax.y + 1f);
            Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);

            currentEnemyCount++;
            if (currentEnemyCount == maxEnemyCount)
            {
                StartCoroutine("SpawnBoss");
                break;
            }

            yield return new WaitForSeconds(spawnTime);
        }
    }

    private IEnumerator SpawnBoss()
    {
        yield return new WaitForSeconds(0.1f);
        boss.SetActive(true);
        boss.GetComponent<Boss>().ChangeState(BossState.MoveToAppearPoint);
    }
}
