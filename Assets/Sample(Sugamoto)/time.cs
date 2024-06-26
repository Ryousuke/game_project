using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class time : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextTime;
    [SerializeField] public TextMeshProUGUI _menuText;
    [SerializeField] private float limitTime;
    public GameObject PanelUIObj;
    public GameObject MenuButtonUIObj;
    public GameObject NextUIObj;
    
    private float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0.0f; //時間を初期化する
    }

    // Update is called once per frame
    void Update()
    {
        //前のフレームからの経過時間(秒)を加算する
        elapsedTime += Time.deltaTime;
        TextTime.text = string.Format("Time {0:f0} sec", limitTime - elapsedTime);//残り時間の表示

        if((limitTime - elapsedTime) < 0)//残り時間０になったとき
        {
            Miss();//ミス判定となる
        }
    }

    //ミスしたときの動作
    private void Miss()
    {
        Time.timeScale = 0;//時間停止
        PanelUIObj.SetActive(true);//メニューの表示
        MenuButtonUIObj.SetActive(false);//メニュー表示ボタンの非表示
        NextUIObj.SetActive(false);//次ステージノボタンの非表示

        _menuText.text = "TIME UP";
    } 
}
