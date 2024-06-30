using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStageObject : MonoBehaviour
{
    Transform myTransform;
    Vector3 position_start;
    Vector3 position_now;
    int stopTime = 0;

    [SerializeField] Vector3 moveSpeed;
    [SerializeField] Vector3 moveRange;
    [SerializeField] float Freq;
    //[SerializeField] int stop;

    void Start()
    {
        myTransform = this.transform;//初期座標の取得
        position_start = myTransform.position;
        position_now = position_start;
    }

    // Update is called once per frame
    void Update()
    {
        //一時停止中ならスクリプトを実行させない
        if (Mathf.Approximately(Time.timeScale, 0f)) 
        {
		return;
	    }

        myTransform.Rotate(0f,Freq,0f,Space.World);
        //オブジェクトの移動
        if(stopTime == 0){
            position_now += moveSpeed/60;
            //Debug.Log((position_now - position_start).magnitude);
            //Debug.Log(moveRange.magnitude);
            if((position_now - position_start).magnitude > moveRange.magnitude)//指定の幅を移動したら向きを変える
            {
                //Debug.Log("turn");
                moveSpeed *= -1;
                //moveRange *= -1;
                position_start = position_now;
                stopTime = 30;
                //stopTime = stop;
            }
        }
        else
        {
            stopTime--;
        }
        myTransform.position = position_now;
    }
}
