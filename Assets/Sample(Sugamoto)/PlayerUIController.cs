using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    //Vector3 position;
    public GameObject PanelUIObj;
    public GameObject ButtonUIObj;
    public GameObject NextUIObj;
    [SerializeField] public TextMeshProUGUI _menuText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Application.targetFrameRate = 60;
        PanelUIObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f)) 
        {
		return;
	    }
        /*
        position = transform.position;

        //position = transform.position;
        
        if(Input.GetKey("up"))//↑なら前に0.1だけ進む
        {
            transform.position += transform.forward*0.1f*playerSpeed;
            //Debug.Log("object = " + position);
        }
        if(Input.GetKey("down"))//↑なら後ろに0.1だけ進む
        {
            transform.position -= transform.forward*0.1f*playerSpeed;
        }
        if(Input.GetKey("right"))//→ならY軸に3度回転する
        {
            transform.Rotate(0f,3.0f,0f);
        }
        if(Input.GetKey("left"))//→ならY軸に-3度回転する
        {
            transform.Rotate(0f,-3.0f,0f);
            
        }
        if(Input.GetKey("space"))//→ならY軸に-3度回転する
        {
            transform.position -= transform.up*0.1f*playerSpeed;
            
        }
        */
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Fall")
        {
            Miss();
            Debug.Log("Miss");
        }
        else if(other.transform.root.gameObject.name == "Enemy")
        {
            Miss();
            Debug.Log("Miss");
        }
        else if(other.gameObject.name == "Goal")
        {
            Clear();
            //Time.timeScale=0;
            Debug.Log("Goal");
        }
    }

    private void Miss()
    {
        Time.timeScale = 0;
        PanelUIObj.SetActive(true);
        ButtonUIObj.SetActive(false);
        NextUIObj.SetActive(false);
        
        _menuText.text = "MISS";
    } 

    private void Clear()
    {
        Miss();
        NextUIObj.SetActive(true);

        _menuText.text = "CLEAR";
    }
}
