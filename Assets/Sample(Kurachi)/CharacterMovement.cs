using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactermovement : MonoBehaviour
{
    public float moveSpeed = 10f; // 移動速度
    public float jumpForce = 5f; // ジャンプ力
    private Rigidbody rb;
    private Camera mainCamera;
    private bool isGrounded;
    private Animator animator; // アニメーター

    public float rotationSpeed = 100f; // カメラ回転速度

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        animator = GetComponent<Animator>(); // アニメーターの取得
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

        // アニメーションの制御
        bool walking = moveHorizontal != 0 || moveVertical != 0;
        animator.SetBool("isWalking", walking);
    }

    void RotateCamera()
    {
        float rotateHorizontal = Input.GetAxis("HorizontalArrow");
        float rotateVertical = Input.GetAxis("VerticalArrow");

        // キャラクターを左右に回転
        transform.Rotate(Vector3.up, rotateHorizontal * rotationSpeed * Time.deltaTime);

        // カメラの垂直方向の回転をキャラクターに反映
        float newPitch = rotateVertical * rotationSpeed * Time.deltaTime;
        float newRotation = mainCamera.transform.eulerAngles.x - newPitch;

        // 上下方向の回転角度を制限する
        if (newRotation > 180f)
        {
            newRotation -= 360f;
        }
        newRotation = Mathf.Clamp(newRotation, -30f, 30f); // 最大30度まで回転可能に制限

        mainCamera.transform.RotateAround(transform.position, mainCamera.transform.right, -newPitch);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;

        // ジャンプアニメーションの制御
        animator.SetBool("isJumping", true);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false); // 着地したらジャンプアニメーションを解除
        }
    }
}
