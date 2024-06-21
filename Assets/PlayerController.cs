using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 position;
    public GameObject PanelUIObj;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        PanelUIObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;

        //position = transform.position;
        
        if(Input.GetKey("up"))//↑なら前に0.1だけ進む
        {
            transform.position += transform.forward*0.1f;
            //Debug.Log("object = " + position);
        }
        if(Input.GetKey("down"))//↑なら後ろに0.1だけ進む
        {
            transform.position -= transform.forward*0.1f;
        }
        if(Input.GetKey("right"))//→ならY軸に3度回転する
        {
            transform.Rotate(0f,3.0f,0f);
        }
        if(Input.GetKey("left"))//→ならY軸に-3度回転する
        {
            transform.Rotate(0f,-3.0f,0f);
            
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Fall")
        {
            PanelUIObj.SetActive(true);
            //Time.timeScale=0;
            Debug.Log("Miss");
        }
        else if(other.transform.root.gameObject.name == "Enemy")
        {
            PanelUIObj.SetActive(true);
            //Time.timeScale=0;
            Debug.Log("Miss");
        }
        else if(other.gameObject.name == "Goal")
        {
            PanelUIObj.SetActive(true);
            //Time.timeScale=0;
            Debug.Log("Goal");
        }
    }
}
