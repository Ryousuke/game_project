using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public GameObject mainCamera;
    //Transform myTransform;
    
    private int rotateY;
    private int count = 180;
    private bool startShake = false;
    // Start is called before the first frame update
    void Start()
    {
        rotateY = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("notShake");
        if(startShake == true)
        {
            if(count > 0)
            {
                mainCamera.transform.Rotate(0,rotateY*1.5f,0f,Space.World);
                rotateY *= -1;
            }
            //Debug.Log("Shake");
            count--;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("key"))
        {
            startShake = true;
            Debug.Log("Shake");
        }
    }
}