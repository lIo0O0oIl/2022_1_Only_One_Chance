using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum BossState { MoveToAppearPoint = 0, Phase01, Phase02, Phase03 }      // 보스가 나타나냐, 현재 페이즈가 몇 이냐

public class Boss : MonoBehaviour
{
    [SerializeField] StageData stageData;
    [SerializeField] float bossAppearPoint = 2.5f;
    [SerializeField] int bossDie = 1000;            // 보스가 죽으면 점수
    private BossState bossState = BossState.MoveToAppearPoint;          // 처음 나타난 것.
    private Movement movement;
    private BossBullet bossBullet;
    private BossHP bossHP;
    Player player;

    private void Awake()
    {
        movement = GetComponent<Movement>();
        bossBullet = GetComponent<BossBullet>();
        bossHP = GetComponent<BossHP>();
        player = FindObjectOfType<Player>();
    }

    public void ChangeState(BossState newState)
    {
        StopCoroutine(bossState.ToString());        // 지금 보스 상태인 것을 멈춰주고
        bossState = newState;
        StartCoroutine(bossState.ToString());       // 들어온 보스의 상태로 바꿔준다.
    }

    private IEnumerator MoveToAppearPoint()
    {
        movement.MoveTo(Vector3.down);      // 아래로 내려갔다가

        while (true)
        {
             if (transform.position.y <= bossAppearPoint)       // 보스가 보스 지정 영역보다 작아지면
            {
                movement.MoveTo(Vector3.zero);
                ChangeState(BossState.Phase01);     // 페이즈 1 시작임
            }
             yield return null;
        }
    }

    private IEnumerator Phase01()
    {
        bossBullet.StartFiring(AttackType.CircleFire);

        while (true)
        {
            if (bossHP.currentHP <= bossHP.maxHP * 0.7f)        // 만약 보스의 채력이 0.7 이하로 내려가면
            {
                bossBullet.StopFiring(AttackType.CircleFire);
                ChangeState(BossState.Phase02);
            }
            yield return null;
        }
    }

    private IEnumerator Phase02()
    {
        bossBullet.StartFiring(AttackType.SingleFireToCenterPosition);      // 한 곳으로 계속 쏴주기

        Vector3 direction = Vector3.right;
        movement.MoveTo(direction);     // 처음으로는 오른쪽으로 이동

        while (true)
        {
            if (transform.position.x <= stageData.LimitMin.x ||         // 왼쪽으로 갔거나 오른쪽으로 갔거나를 감지해서 반대방향으로 계속 가게 해줌.
                transform.position.x >= stageData.LimitMax.x)
            {
                direction *= -1;
                movement.MoveTo(direction);
            }

            if (bossHP.currentHP <= bossHP.maxHP * 0.3f)        // 만약 보스의 체력이 0.3 이하로 내려가면
            {
                bossBullet.StopFiring(AttackType.SingleFireToCenterPosition);
                ChangeState(BossState.Phase03);
            }

            yield return null;
        }
    }

    private IEnumerator Phase03()
    {
        bossBullet.StartFiring(AttackType.CircleFire);
        bossBullet.StartFiring(AttackType.SingleFireToCenterPosition);          // 두개 다 사용해주기

        Vector3 direction = Vector3.right;
        movement.MoveTo(direction);

        while (true)
        {
            if (transform.position.x <= stageData.LimitMin.x ||
                transform.position.x >= stageData.LimitMax.x)
            {
                direction *= -1;
                movement.MoveTo(direction);             // 계속 죄우로 왔다 갔다가 함.
            }

            yield return null;
        }
    }

    public void OnDie()
    {
        player.Score += bossDie;
        Destroy(gameObject);
        SceneManager.LoadScene("GameClaer");        // 점수추가해주고 씬 이동해주기
    }
}
