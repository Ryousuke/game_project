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
    // Start is called before the first frame update
    void Start()
    {
        //_text.text = "MENU";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        if(_text.text == "MENU")
        {
            //Debug.Log("Push MENU");
            _text.text = "CLOSE";
            _text.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            //button.colors = Color.black;
            GetComponent<Image>().color = Color.black;
            PanelUIObj.SetActive(true);
            
            NextUIObj.SetActive(false);
        }
        else
        {
            //Debug.Log("Push CLOSE");
            _text.text = "MENU";
            _text.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
            //button.colors = Color.white;
            GetComponent<Image>().color = Color.white;
            PanelUIObj.SetActive(false);
            NextUIObj.SetActive(false);
        }     
    }
}
