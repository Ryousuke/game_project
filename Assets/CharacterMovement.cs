using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 10f; // 移動速度
    public float jumpForce = 5f; // ジャンプ力
    private Rigidbody rb;
    private Camera mainCamera;
    private bool isGrounded;

    public float rotationSpeed = 100f; // カメラ回転速度

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
        float moveVertical = -Input.GetAxis("VerticalWASD"); // 前後の動きを反転

        // カメラの前方向と右方向を取得
        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;

        // Y軸方向の成分をゼロにして、XZ平面に投影
        cameraForward.y = 0;
        cameraRight.y = 0;

        cameraForward.Normalize();
        cameraRight.Normalize();

        // カメラの方向に基づいて移動ベクトルを計算
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
