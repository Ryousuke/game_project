using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownFloor3 : MonoBehaviour
{
    Transform myTransform;
    Vector3 position_start;
    // Start is called before the first frame update
    void Start()
    {
        myTransform = this.transform;
        position_start = myTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float posY = position_start.y - Mathf.Sin(Time.time) * 3;
        transform.position = new Vector3(transform.position.x, posY, transform.position.z);
    }
}
