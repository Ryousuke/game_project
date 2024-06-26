using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableWall : MonoBehaviour
{
    public Vector3 targetPosition; // 壁が移動する目標位置
    public float speed = 5f; // 壁の移動速度

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    public void MoveWall()
    {
        StartCoroutine(MoveToTarget());
    }

    IEnumerator MoveToTarget()
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
    }
}
