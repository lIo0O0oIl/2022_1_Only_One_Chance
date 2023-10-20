using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // dir 쪽으로 계속해서 움직임
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
