using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public GameObject mainCamera;
    //Transform myTransform;
    
    private int rotateY;
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
            //Debug.Log("Shake");

            mainCamera.transform.Rotate(0,rotateY*1.5f,0f,Space.World);
            rotateY *= -1;
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
/*
    IEnumerator CameraShake()
    {
        for(int i = 0; i < 50; i++)
        {
            mainCamera.transform.Translate(moveX, 0, 0);
            moveX *= -1;
            yield return new WaitForSeconds(0.01f);
        }
    }
*/
}
