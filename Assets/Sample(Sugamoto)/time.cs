using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class time : MonoBehaviour
{
    //Textを外部に出力するための変数を定義する
    //[...]をつけることで、内部変数がインスペクターから操作できるようになる
    //privateをpublicにしても操作可能になる
    [SerializeField] private TextMeshProUGUI TextTime;
    [SerializeField] private TextMeshProUGUI GoalMessage;
    [SerializeField] private float limitTime;

    private float elapsedTime;

    private int f_Goal;
    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0.0f; //時間を初期化する
    }

    // Update is called once per frame
    void Update()
    {
        if(f_Goal == 0)
        {
            //前のフレームからの経過時間(秒)を加算する
            elapsedTime += Time.deltaTime;
        }
        //経過時間を表示するために、経過時間を秒にしたストリングを作成する
        TextTime.text = string.Format("Time {0:f0} sec", limitTime - elapsedTime);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Goal")
        {
            f_Goal = 1;
           // GoalMessage.text = "Goal!";
        }
    }
}
