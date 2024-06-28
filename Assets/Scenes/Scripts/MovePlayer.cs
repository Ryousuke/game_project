using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up")) // ���Ȃ�O�iZ �����j�� 0.15 �����i��
        {
            transform.position += transform.forward * 0.15f;
        }
        if (Input.GetKey("down")) // ���Ȃ�-Z ������ 0.15 �����i��
        {
            transform.position -= transform.forward * 0.15f;
        }
        if (Input.GetKey("right")) // ���Ȃ� Y ���� 3 �x��]����
        {
            transform.Rotate(0f, 3.0f, 0f);
        }
        if (Input.GetKey("left")) // ���Ȃ� Y ����-3 �x��]����
        {
            transform.Rotate(0f, -3.0f, 0f);
        }
    }
}
