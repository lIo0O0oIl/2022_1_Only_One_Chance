using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType { CircleFire = 0, SingleFireToCenterPosition }       // 보스의 패턴. 원으로 공격, 센터에 하나씩 공 던지기

public class BossBullet : MonoBehaviour
{
    [SerializeField] GameObject BulletPrefab;

    public void StartFiring(AttackType attackType)      // 공격 시작
    {
        StartCoroutine(attackType.ToString());
    }

    public void StopFiring(AttackType attackType)       // 이 공격은 멈춰라
    {
        StopCoroutine(attackType.ToString());
    }

    public IEnumerator CircleFire()     // 동그랗고 퍼지는 탄
    {
        float attacRate = 0.5f;     // 총알의 기다림...?
        int count = 30;     // 총 30개 던져줌.
        float intervalAngle = 360 / count;      // 서로 발사되는 각도
        float weightAngle = 0;

        while (true)
        {
            for (int i = 0; i < count; ++ i)
            {
                GameObject clone = Instantiate(BulletPrefab, transform.position, Quaternion.identity);      // 일단 쏜 다음에
                float angle = weightAngle + intervalAngle * i;      // 발사되는 각도  + 나 + 다음 단계선 이만큼 더 더해주자.
                float x = Mathf.Cos(angle * Mathf.Deg2Rad);     // 밑변
                float y = Mathf.Sin(angle * Mathf.Deg2Rad);     // 높이 = 꼭짓점. 날라가는 방향.                                   https://sinsa0918.tistory.com/2 이거 참고하기
                clone.GetComponent<Movement>().MoveTo(new Vector2(x, y));       // 날라가는 방향을 정해줌.
            }

            weightAngle += 1;

            yield return new WaitForSeconds(attacRate);
        }
    }

    private IEnumerator SingleFireToCenterPosition()        // 보스가 계속해서 움직이고 한 방향으로 총알을 쏴줌
    {
        Vector3 targetPosition = Vector3.zero;
        float attackRate = 0.2f;

        while (true)
        {
            GameObject clone = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            Vector3 direction = (targetPosition - clone.transform.position).normalized;         // 생성해주고 가운데로 방향 설정해주고 attackRate마다 날리기
            clone.GetComponent<Movement>().MoveTo(direction);

            yield return new WaitForSeconds(attackRate);
        }
    }
}
