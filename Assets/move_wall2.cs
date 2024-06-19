using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_wall2 : MonoBehaviour
{
    Transform myTransform; // transform 情報を格納する変数
    Vector3 position_start; // 物体の初期位置を格納する変数
    Vector3 position_end; // 物体の逆方向の位置を格納する変数
    float speed = 0.05f; // 移動速度

    // Start is called before the first frame update
    void Start()
    {
        myTransform = this.transform; // 物体の transform 情報をリンクする
        position_start = myTransform.position; // 初期位置を取り出す
        position_end = position_start + new Vector3(0, 0, -5); // Z 方向に 5 移動した位置
        StartCoroutine(MoveWall()); // コルーチンを開始する
    }

    // コルーチンで移動と停止を管理する
    IEnumerator MoveWall()
    {
        while (true)
        {
            // Z 方向に 5 移動
            while (Vector3.Distance(myTransform.position, position_end) > 0.01f)
            {
                myTransform.position = Vector3.MoveTowards(myTransform.position, position_end, speed);
                yield return null; // 次のフレームまで待機
            }

            // 2秒間停止
            yield return new WaitForSeconds(2);

            // 逆方向に 5 移動
            while (Vector3.Distance(myTransform.position, position_start) > 0.01f)
            {
                myTransform.position = Vector3.MoveTowards(myTransform.position, position_start, speed);
                yield return null; // 次のフレームまで待機
            }

            // 2秒間停止
            yield return new WaitForSeconds(2);
        }
    }
}
