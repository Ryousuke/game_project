using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target; // キャラクターのTransform
    public float moveSpeed = 10f; // カメラ移動速度
    public float rotationSpeed = 100f; // カメラ回転速度

    private void Update()
    {
        Move();
        RotateCharacter();
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("HorizontalWASD");
        float moveVertical = Input.GetAxis("VerticalWASD");

        // カメラの前方向と右方向を取得
        Vector3 cameraForward = transform.forward;
        Vector3 cameraRight = transform.right;

        // Y軸方向の成分をゼロにして、XZ平面に投影
        cameraForward.y = 0;
        cameraRight.y = 0;

        cameraForward.Normalize();
        cameraRight.Normalize();

        // カメラの方向に基づいて移動ベクトルを計算
        Vector3 movement = (cameraForward * moveVertical + cameraRight * moveHorizontal) * moveSpeed * Time.deltaTime;

        transform.position += movement;
    }

    void RotateCharacter()
    {
        float rotateHorizontal = Input.GetAxis("HorizontalArrow");
        float rotateVertical = Input.GetAxis("VerticalArrow");

        // キャラクターを左右に回転
        target.Rotate(Vector3.up, rotateHorizontal * rotationSpeed * Time.deltaTime);

        // カメラの垂直方向の回転をキャラクターに反映
        float newPitch = rotateVertical * rotationSpeed * Time.deltaTime;
        transform.RotateAround(target.position, transform.right, -newPitch);
    }

    private void LateUpdate()
    {
        // カメラをキャラクターの後ろに配置する
        Vector3 offset = -transform.forward * 5f + transform.up * 1f; // キャラクターの後ろに5単位だけ配置し、上に1単位オフセット
        transform.position = target.position + offset;
    }
}
