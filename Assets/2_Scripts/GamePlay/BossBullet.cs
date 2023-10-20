using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType { CircleFire = 0, SingleFireToCenterPosition }       // ������ ����. ������ ����, ���Ϳ� �ϳ��� �� ������

public class BossBullet : MonoBehaviour
{
    [SerializeField] GameObject BulletPrefab;

    public void StartFiring(AttackType attackType)      // ���� ����
    {
        StartCoroutine(attackType.ToString());
    }

    public void StopFiring(AttackType attackType)       // �� ������ �����
    {
        StopCoroutine(attackType.ToString());
    }

    public IEnumerator CircleFire()     // ���׶��� ������ ź
    {
        float attacRate = 0.5f;     // �Ѿ��� ��ٸ�...?
        int count = 30;     // �� 30�� ������.
        float intervalAngle = 360 / count;      // ���� �߻�Ǵ� ����
        float weightAngle = 0;

        while (true)
        {
            for (int i = 0; i < count; ++ i)
            {
                GameObject clone = Instantiate(BulletPrefab, transform.position, Quaternion.identity);      // �ϴ� �� ������
                float angle = weightAngle + intervalAngle * i;      // �߻�Ǵ� ����  + �� + ���� �ܰ輱 �̸�ŭ �� ��������.
                float x = Mathf.Cos(angle * Mathf.Deg2Rad);     // �غ�
                float y = Mathf.Sin(angle * Mathf.Deg2Rad);     // ���� = ������. ���󰡴� ����.                                   https://sinsa0918.tistory.com/2 �̰� �����ϱ�
                clone.GetComponent<Movement>().MoveTo(new Vector2(x, y));       // ���󰡴� ������ ������.
            }

            weightAngle += 1;

            yield return new WaitForSeconds(attacRate);
        }
    }

    private IEnumerator SingleFireToCenterPosition()        // ������ ����ؼ� �����̰� �� �������� �Ѿ��� ����
    {
        Vector3 targetPosition = Vector3.zero;
        float attackRate = 0.2f;

        while (true)
        {
            GameObject clone = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            Vector3 direction = (targetPosition - clone.transform.position).normalized;         // �������ְ� ����� ���� �������ְ� attackRate���� ������
            clone.GetComponent<Movement>().MoveTo(direction);

            yield return new WaitForSeconds(attackRate);
        }
    }
}
