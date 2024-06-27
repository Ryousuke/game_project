using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWallNormal : MonoBehaviour
{
    Transform myTransform;
    Vector3 origin = new Vector3(10f, 1f, 18f);
    Vector3 axis = new Vector3(0f, 1f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        myTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        myTransform.RotateAround(origin, axis, 3f);
    }
}
