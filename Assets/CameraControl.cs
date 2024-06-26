using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target; // �L�����N�^�[��Transform
    public float moveSpeed = 10f; // �J�����ړ����x
    public float rotationSpeed = 100f; // �J������]���x

    private void Update()
    {
        Move();
        RotateCharacter();
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("HorizontalWASD");
        float moveVertical = Input.GetAxis("VerticalWASD");

        // �J�����̑O�����ƉE�������擾
        Vector3 cameraForward = transform.forward;
        Vector3 cameraRight = transform.right;

        // Y�������̐������[���ɂ��āAXZ���ʂɓ��e
        cameraForward.y = 0;
        cameraRight.y = 0;

        cameraForward.Normalize();
        cameraRight.Normalize();

        // �J�����̕����Ɋ�Â��Ĉړ��x�N�g�����v�Z
        Vector3 movement = (cameraForward * moveVertical + cameraRight * moveHorizontal) * moveSpeed * Time.deltaTime;

        transform.position += movement;
    }

    void RotateCharacter()
    {
        float rotateHorizontal = Input.GetAxis("HorizontalArrow");
        float rotateVertical = Input.GetAxis("VerticalArrow");

        // �L�����N�^�[�����E�ɉ�]
        target.Rotate(Vector3.up, rotateHorizontal * rotationSpeed * Time.deltaTime);

        // �J�����̐��������̉�]���L�����N�^�[�ɔ��f
        float newPitch = rotateVertical * rotationSpeed * Time.deltaTime;
        transform.RotateAround(target.position, transform.right, -newPitch);
    }

    private void LateUpdate()
    {
        // �J�������L�����N�^�[�̌��ɔz�u����
        Vector3 offset = -transform.forward * 5f + transform.up * 1f; // �L�����N�^�[�̌���5�P�ʂ����z�u���A���1�P�ʃI�t�Z�b�g
        transform.position = target.position + offset;
    }
}
