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
                Instantiate(BulletPrefab, transform.position, Quaternion.identity);     // �տ� ���� ����
                GetComponent<Mana>().UseMana(useMana);      // ������ �Ǿ����� ������ �ٿ��ֱ�
                yield return new WaitForSeconds(attackRate);
            }
    }
}
