using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableWall : MonoBehaviour
{
    public Vector3 targetPosition; // �ǂ��ړ�����ڕW�ʒu
    public float speed = 5f; // �ǂ̈ړ����x

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
