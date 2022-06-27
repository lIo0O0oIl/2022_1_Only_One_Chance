using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] float maxHP = 10;
    float currentHP;
    SpriteRenderer spriteRenderer;
    //Player player;
    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;

    void Start()
    {
        currentHP = maxHP;
        spriteRenderer = GetComponent<SpriteRenderer>();
        //player = GetComponent<Player>();
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;

        StopCoroutine("HitColor");
        StartCoroutine("HitColor");

        if (currentHP <= 0)
        {
            GetComponent<Player>().OnDie();
        }
    }

    IEnumerator HitColor()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.green;
    }
}
