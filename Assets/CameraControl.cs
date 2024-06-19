using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target; // �^�[�Q�b�g�ƂȂ�I�u�W�F�N�g�i�L�����N�^�[�j
    public float distance = 5.0f; // �^�[�Q�b�g�Ƃ̋���
    public float heightOffset = 2.0f; // �J�����̍����I�t�Z�b�g
    public float rotationSpeed = 100.0f; // �J�����̉�]���x

    private float currentX = 0.0f;
    private float currentY = 0.0f;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        currentX = angles.y;
        currentY = angles.x;
    }

    void LateUpdate()
    {
        if (target)
        {
            // ���L�[�ŃJ��������]
            float horizontal = Input.GetAxis("HorizontalArrow") * rotationSpeed * Time.deltaTime;
            float vertical = -Input.GetAxis("VerticalArrow") * rotationSpeed * Time.deltaTime;

            currentX += horizontal;
            currentY = Mathf.Clamp(currentY + vertical, -40, 40);

            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
            Vector3 position = target.position - (rotation * Vector3.forward * distance) + (Vector3.up * heightOffset);

            transform.rotation = rotation;
            transform.position = position;
        }
    }
}

