using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // dir ������ ����ؼ� ������
    [SerializeField] float speed;
    [SerializeField] Vector3 direction;

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    public void MoveTo(Vector3 dir)
    {
        direction = dir;
    }
}
