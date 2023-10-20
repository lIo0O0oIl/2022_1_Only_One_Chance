using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// º¸½ºÀÇ ÃÑ¾Ë
public class Enemytile : MonoBehaviour
{
    [SerializeField] int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHP>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
