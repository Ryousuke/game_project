using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayButton : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI _text;
    public Color color;
    [SerializeField] public Button button;
    public GameObject PanelUIObj;
    public GameObject NextUIObj;

    public void OnClick()//クリックされたときの動作
    {
        if(_text.text == "MENU")//メニューボタンを押されたとき
        {
            //Debug.Log("Push MENU");
            Time.timeScale = 0;//時間停止
            _text.text = "CLOSE";//テキストを"CLOSE"に
            _text.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);//テキストカラーを白に
            GetComponent<Image>().color = Color.black;//ボタンカラーを黒に
            PanelUIObj.SetActive(true);//メニュー画面の表示
            NextUIObj.SetActive(false);//次のステージのボタンを非表示
        }
        else//クローズボタンを押されたとき
        {
            //Debug.Log("Push CLOSE");
            Time.timeScale = 1;//時間停止の解除
            _text.text = "MENU";//テキストを"MENU"に
            _text.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);//テキストカラーを黒に
            GetComponent<Image>().color = Color.white;//ボタンカラーを白に
            PanelUIObj.SetActive(false);//メニュー画面の非表示
        }     
    }
}
