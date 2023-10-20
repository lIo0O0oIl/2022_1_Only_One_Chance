using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletile : MonoBehaviour
{
    // 플레이어의 총알
    [SerializeField] int damage = 1;
    [SerializeField] int scorePoint = 25;       // 보스를 맞추면 이런 점수가 들어감.
    Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            //Destroy(collision.gameObject);
            collision.GetComponent<Enemy>().DieDie();       // 에너미에 맞으면 에너미 죽이기
        }
        else if (collision.CompareTag("Boss"))      // 보스에 맞은거면
        {
            collision.GetComponent<BossHP>().TakeDamage(damage);        // 보스에게 공격함.
            Destroy(gameObject);
            player.Score += scorePoint;
        }
    }
}
