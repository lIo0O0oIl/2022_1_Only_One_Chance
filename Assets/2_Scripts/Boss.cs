using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum BossState { MoveToAppearPoint = 0, Phase01, Phase02, Phase03 }

public class Boss : MonoBehaviour
{
    [SerializeField] StageData stageData;
    [SerializeField] float bossAppearPoint = 2.5f;
    [SerializeField] int bossDie = 1000;
    private BossState bossState = BossState.MoveToAppearPoint;
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
        StopCoroutine(bossState.ToString());
        bossState = newState;
        StartCoroutine(bossState.ToString());
    }

    private IEnumerator MoveToAppearPoint()
    {
        movement.MoveTo(Vector3.down);

        while (true)
        {
             if (transform.position.y <= bossAppearPoint)
            {
                movement.MoveTo(Vector3.zero);
                ChangeState(BossState.Phase01);
            }
             yield return null;
        }
    }

    private IEnumerator Phase01()
    {
        bossBullet.StartFiring(AttackType.CircleFire);

        while (true)
        {
            if (bossHP.currentHP <= bossHP.maxHP * 0.7f)
            {
                bossBullet.StopFiring(AttackType.CircleFire);
                ChangeState(BossState.Phase02);
            }
            yield return null;
        }
    }

    private IEnumerator Phase02()
    {
        bossBullet.StartFiring(AttackType.SingleFireToCenterPosition);

        Vector3 direction = Vector3.right;
        movement.MoveTo(direction);

        while (true)
        {
            if (transform.position.x <= stageData.LimitMin.x ||
                transform.position.x >= stageData.LimitMax.x)
            {
                direction *= -1;
                movement.MoveTo(direction);
            }

            if (bossHP.currentHP <= bossHP.maxHP * 0.3f)
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
        bossBullet.StartFiring(AttackType.SingleFireToCenterPosition);

        Vector3 direction = Vector3.right;
        movement.MoveTo(direction);

        while (true)
        {
            if (transform.position.x <= stageData.LimitMin.x ||
                transform.position.x >= stageData.LimitMax.x)
            {
                direction *= -1;
                movement.MoveTo(direction);
            }

            yield return null;
        }
    }

    public void OnDie()
    {
        player.Score += bossDie;
        Destroy(gameObject);
        SceneManager.LoadScene("GameClear");
    }
}
