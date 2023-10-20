using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] float attackRate = 0.1f;
    [SerializeField] float useMana = 0.5f;
    Mana mana;

    public void StartFiring()
    {
            StartCoroutine("TryAttack");
    }

    public void StopFiring()
    {
        StopCoroutine("TryAttack");
    }

    IEnumerator TryAttack()
    {
            while (true)
            {
                Instantiate(BulletPrefab, transform.position, Quaternion.identity);     // 앞에 보고 쏘자
                GetComponent<Mana>().UseMana(useMana);      // 공격이 되었으니 마나를 줄여주기
                yield return new WaitForSeconds(attackRate);
            }
    }
}
