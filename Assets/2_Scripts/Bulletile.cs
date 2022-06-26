using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletile : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] int scorePoint = 25;
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
            collision.GetComponent<Enemy>().DieDie();
        }
        else if (collision.CompareTag("Boss"))
        {
            collision.GetComponent<BossHP>().TakeDamage(damage);
            Destroy(gameObject);
            player.Score += scorePoint;
        }
    }
}
