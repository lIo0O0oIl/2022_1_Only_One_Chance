using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] StageData stageData;
    [SerializeField] KeyCode keyAttackCode = KeyCode.Space;
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
        movement.MoveTo(new Vector3(x, y, 0));

        if (Input.GetKeyDown(keyAttackCode))
            {
            if (manamana) bullet.StartFiring();
            }
        else if (manamana == false)
        {
            bullet.StopFiring();
        }
            else if (Input.GetKeyUp(keyAttackCode))
            {
                bullet.StopFiring();
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
            , Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y), 0);
    }

    int score;
    public int Score
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
}
