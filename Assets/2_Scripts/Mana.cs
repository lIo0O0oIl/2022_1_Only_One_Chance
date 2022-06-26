using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    Player player;
    [SerializeField] float maxMana = 10;
    public float currentMana;
    SpriteRenderer spriteRenderer;
    public float MaxMana => maxMana;
    public float CurrentMana => currentMana;
    void Start()
    {
        currentMana = maxMana;
        spriteRenderer = GetComponent<SpriteRenderer>();
        //player = GetComponent<Player>();
    }

    private void Update()
    {
        if (currentMana <= 0)
        {
            GetComponent<Player>().mana1();
        }
        else
        {
            GetComponent<Player>().mana2();
        }
    }

    public void UseMana(float mana)
    {
        currentMana -= mana;

        
    }
}
