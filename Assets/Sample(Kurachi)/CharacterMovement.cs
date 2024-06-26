using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 10f; // �ړ����x
    public float jumpForce = 5f; // �W�����v��
    private Rigidbody rb;
    private Camera mainCamera;
    private bool isGrounded;

    public float rotationSpeed = 100f; // �J������]���x

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        Move();
        RotateCamera();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("HorizontalWASD");
        float moveVertical = -Input.GetAxis("VerticalWASD"); // �O��̓����𔽓]

        // �J�����̑O�����ƉE�������擾
        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;

        // Y�������̐������[���ɂ��āAXZ���ʂɓ��e
        cameraForward.y = 0;
        cameraRight.y = 0;

        cameraForward.Normalize();
        cameraRight.Normalize();

        // �J�����̕����Ɋ�Â��Ĉړ��x�N�g�����v�Z
        Vector3 movement = (cameraForward * moveVertical + cameraRight * moveHorizontal) * moveSpeed * Time.deltaTime;

        rb.MovePosition(transform.position + movement);
    }

    void RotateCamera()
    {
        if(Input.GetKey("up"))
        {
            Debug.Log("ArrowUp");
        }
        float rotateHorizontal = Input.GetAxis("HorizontalArrow");
        float rotateVertical = Input.GetAxis("VerticalArrow");

        // �L�����N�^�[�����E�ɉ�]
        transform.Rotate(Vector3.up, rotateHorizontal * rotationSpeed * Time.deltaTime);

        // �J�����̐��������̉�]���L�����N�^�[�ɔ��f
        float newPitch = rotateVertical * rotationSpeed * Time.deltaTime;
        float newRotation = mainCamera.transform.eulerAngles.x - newPitch;

        // �㉺�����̉�]�p�x�𐧌�����
        if (newRotation > 180f)
        {
            newRotation -= 360f;
        }
        newRotation = Mathf.Clamp(newRotation, -30f, 30f); // �ő�30�x�܂ŉ�]�\�ɐ���

        mainCamera.transform.RotateAround(transform.position, mainCamera.transform.right, -newPitch);
    }


    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
