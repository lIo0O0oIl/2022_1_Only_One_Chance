using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            //Destroy(collision.gameObject);
            collision.GetComponent<Enemy>().DieDie();
        }
    }
}
