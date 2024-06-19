using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_wall2 : MonoBehaviour
{
    Transform myTransform; // transform �����i�[����ϐ�
    Vector3 position_start; // ���̂̏����ʒu���i�[����ϐ�
    Vector3 position_end; // ���̂̋t�����̈ʒu���i�[����ϐ�
    float speed = 0.05f; // �ړ����x

    // Start is called before the first frame update
    void Start()
    {
        myTransform = this.transform; // ���̂� transform ���������N����
        position_start = myTransform.position; // �����ʒu�����o��
        position_end = position_start + new Vector3(0, 0, -5); // Z ������ 5 �ړ������ʒu
        StartCoroutine(MoveWall()); // �R���[�`�����J�n����
    }

    // �R���[�`���ňړ��ƒ�~���Ǘ�����
    IEnumerator MoveWall()
    {
        while (true)
        {
            // Z ������ 5 �ړ�
            while (Vector3.Distance(myTransform.position, position_end) > 0.01f)
            {
                myTransform.position = Vector3.MoveTowards(myTransform.position, position_end, speed);
                yield return null; // ���̃t���[���܂őҋ@
            }

            // 2�b�Ԓ�~
            yield return new WaitForSeconds(2);

            // �t������ 5 �ړ�
            while (Vector3.Distance(myTransform.position, position_start) > 0.01f)
            {
                myTransform.position = Vector3.MoveTowards(myTransform.position, position_start, speed);
                yield return null; // ���̃t���[���܂őҋ@
            }

            // 2�b�Ԓ�~
            yield return new WaitForSeconds(2);
        }
    }
}
