using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_wall2 : MonoBehaviour
{
    public Transform pivot; // 壁の端を中心とする回転軸

    private Quaternion openRightRotation; // 右方向に開いた状態の回転
    private Quaternion openLeftRotation; // 左方向に開いた状態の回転
    private Quaternion closedRotation; // 閉じた状態の回転
    private float rotationSpeed = 2f; // 回転速度
    private float waitTime = 2f; // 待機時間

    void Start()
    {
        if (pivot == null)
        {
            Debug.LogError("Pivot is not assigned.");
            return;
        }

        openRightRotation = Quaternion.Euler(0, 90, 0); // 90度右に開いた状態の回転
        openLeftRotation = Quaternion.Euler(0, -90, 0); // 90度左に開いた状態の回転
        closedRotation = Quaternion.Euler(0, 0, 0); // 閉じた状態の回転
        StartCoroutine(RotateWallRoutine()); // コルーチンを開始する
    }

    IEnumerator RotateWallRoutine()
    {
        while (true)
        {
            // 壁を右方向に90度回転させて開く
            yield return RotateTo(openRightRotation);
            yield return new WaitForSeconds(waitTime);
            // 壁を元の位置に戻して閉じる
            yield return RotateTo(closedRotation);
            yield return new WaitForSeconds(waitTime);
            // 壁を左方向に90度回転させて開く
            yield return RotateTo(openLeftRotation);
            yield return new WaitForSeconds(waitTime);
            // 壁を元の位置に戻して閉じる
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