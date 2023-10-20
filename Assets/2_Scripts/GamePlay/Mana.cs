using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    [SerializeField] float maxMana = 10;
    public float currentMana;
    public float MaxMana => maxMana;
    public float CurrentMana => currentMana;

    void Start()
    {
        currentMana = maxMana;
    }

    private void Update()
    {
        if (currentMana <= 0)
        {
            GetComponent<Player>().mana1();         // 마나 없어, false
        }
        else
        {
            GetComponent<Player>().mana2();         // 마나 있어, true
        }
    }

    public void UseMana(float mana)
    {
        currentMana -= mana;
    }
}
