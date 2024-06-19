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
        float rotateHorizontal = Input.GetAxis("HorizontalArrow");
        float rotateVertical = Input.GetAxis("VerticalArrow");

        mainCamera.transform.RotateAround(transform.position, Vector3.up, rotateHorizontal * rotationSpeed * Time.deltaTime);
        mainCamera.transform.RotateAround(transform.position, mainCamera.transform.right, -rotateVertical * rotationSpeed * Time.deltaTime);
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
