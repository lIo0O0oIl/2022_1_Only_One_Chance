using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float damage = 1f;
    [SerializeField] int scorePoint = 100;
    Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    [SerializeField]  float speed = 6;
    Vector3 dir;

    private void Start()
    {
        int rd = Random.Range(0, 10);//0~9
        if (rd < 4)
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;       // 절반의 확률로 나에게 오거나 아래로 그냥 가거나
            //dir = (dir.magnitude!=1)? dir.normalized:dir;
            dir.Normalize();

        }
        else
        {
            dir = Vector3.down;
        }
    }

    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);      // 계속 dir 로 갈게~
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHP>().TakeDamage(damage);      // 플레이어에 맞으면
            Destroy(gameObject);
        }
    }

    public void DieDie()        // 내가 죽으면
    {
        player.Score += scorePoint;
        Destroy(gameObject);
    }
}
