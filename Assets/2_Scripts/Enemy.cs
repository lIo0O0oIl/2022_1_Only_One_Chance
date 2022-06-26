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

    [SerializeField]  float speed = 5;
    Vector3 dir;
    private void Start()
    {
        int rd = Random.Range(0, 10);//0~9
        if (rd < 4)
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;
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
        transform.Translate(dir * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHP>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    public void DieDie()
    {
        player.Score += scorePoint;
        Destroy(gameObject);
    }
}
