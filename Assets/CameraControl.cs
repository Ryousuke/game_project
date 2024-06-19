using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target; // ターゲットとなるオブジェクト（キャラクター）
    public float distance = 5.0f; // ターゲットとの距離
    public float heightOffset = 2.0f; // カメラの高さオフセット
    public float rotationSpeed = 100.0f; // カメラの回転速度

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
            // 矢印キーでカメラを回転
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

