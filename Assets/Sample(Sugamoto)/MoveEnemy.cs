using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    Transform myTransform;
    Vector3 position_start;
    Vector3 position_now;
    private int rotate = 0;
    [SerializeField] Vector3 moveSpeed;
    [SerializeField] Vector3 moveRange;
    [SerializeField] int rotatable;

    // Start is called before the first frame update
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
        
        if(rotate == 0)
        {
            //オブジェクトの移動
            position_now += moveSpeed/60;
            myTransform.position = position_now;
            rotate = 0;
            Debug.Log(position_now - position_start);
            Debug.Log(moveRange);
            if(position_now - position_start == moveRange)//指定の幅を移動したら向きを変える
            {
                Debug.Log("turn");
                moveSpeed *= -1;
                moveRange *= -1;
                position_start = position_now;
                rotate = 120;
            }
        }
        
        else//指定の速さで向きを変える
        {
            if(rotatable != 0)
            {
                myTransform.Rotate(0f,1.5f,0f,Space.World);
                rotate--;
            }
        }
    }
}
