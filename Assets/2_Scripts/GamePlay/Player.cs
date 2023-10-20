using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] StageData stageData;
    [SerializeField] KeyCode keyAttackCode = KeyCode.Space;     // 공격 키
    Movement movement;
    Bullet bullet;
    bool manamana;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
        bullet = GetComponent<Bullet>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        movement.MoveTo(new Vector3(x, y, 0));          // 이렇게 움직여라

        if (Input.GetKeyDown(keyAttackCode))
        {
            Debug.Log("공격중");
            if (manamana) bullet.StartFiring();     // 마나가 있어서 쏠 수 있으면 시작
        }
        else if (manamana == false)     // 눌렀는데 마나가 없으면
        {
            bullet.StopFiring();
        }
        else if (Input.GetKeyUp(keyAttackCode))
        {
            bullet.StopFiring();        // 올라가면 쏘지 못하게 해줌
        }
        
    }

    public void mana1()
    {
        manamana = false;
    }

    public void mana2()
    {
        manamana = true;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x)
            , Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y), 0);        // 움직임 제한해줌.
    }

    int score;
    public int Score        // 스코어 프로퍼티
    {
        set => score = Mathf.Max(0, value);
        get => score;
    }

    int mana;
    public int Mana
    {
        set => mana = Mathf.Max(0, value);
        get => mana;
    }

    public void OnDie()
    {
        PlayerPrefs.SetInt("Score", score);
        SceneManager.LoadScene("GameOver");         // 죽으면 점수 저장해주고 씬 넘기기
    }
}
