using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_wall2 : MonoBehaviour
{
    public Transform pivot; // �ǂ̒[�𒆐S�Ƃ����]��

    private Quaternion openRightRotation; // �E�����ɊJ������Ԃ̉�]
    private Quaternion openLeftRotation; // �������ɊJ������Ԃ̉�]
    private Quaternion closedRotation; // ������Ԃ̉�]
    private float rotationSpeed = 2f; // ��]���x
    private float waitTime = 2f; // �ҋ@����

    void Start()
    {
        if (pivot == null)
        {
            Debug.LogError("Pivot is not assigned.");
            return;
        }

        openRightRotation = Quaternion.Euler(0, 90, 0); // 90�x�E�ɊJ������Ԃ̉�]
        openLeftRotation = Quaternion.Euler(0, -90, 0); // 90�x���ɊJ������Ԃ̉�]
        closedRotation = Quaternion.Euler(0, 0, 0); // ������Ԃ̉�]
        StartCoroutine(RotateWallRoutine()); // �R���[�`�����J�n����
    }

    IEnumerator RotateWallRoutine()
    {
        while (true)
        {
            // �ǂ��E������90�x��]�����ĊJ��
            yield return RotateTo(openRightRotation);
            yield return new WaitForSeconds(waitTime);
            // �ǂ����̈ʒu�ɖ߂��ĕ���
            yield return RotateTo(closedRotation);
            yield return new WaitForSeconds(waitTime);
            // �ǂ���������90�x��]�����ĊJ��
            yield return RotateTo(openLeftRotation);
            yield return new WaitForSeconds(waitTime);
            // �ǂ����̈ʒu�ɖ߂��ĕ���
            yield return RotateTo(closedRotation);
            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerator RotateTo(Quaternion targetRotation)
    {
        while (Quaternion.Angle(pivot.localRotation, targetRotation) > 0.01f)
        {
            pivot.localRotation = Quaternion.Slerp(pivot.localRotation, targetRotation, Time.deltaTime * rotationSpeed);
            yield return null;
        }
        pivot.localRotation = targetRotation;
    }
}