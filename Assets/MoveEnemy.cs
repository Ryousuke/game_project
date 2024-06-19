using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    Transform myTransform;
    Vector3 position_start;
    Vector3 position_now;
    private int rotate = 0;
    [SerializeField] Vector3 moveSpeed;
    [SerializeField] Vector3 moveRange;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = this.transform;
        position_start = myTransform.position;
        position_now = position_start;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(position_now);
        
        if(rotate == 0)
        {
            position_now += moveSpeed/60;
            myTransform.position = position_now;
            rotate = 0;
        }
        if(position_now - position_start == moveRange)
        {
            moveSpeed *= -1;
            moveRange *= -1;
            position_start = position_now;
            rotate = 120;
        }
        
        if(rotate != 0) 
        {
            myTransform.Rotate(0f,1.5f,0f,Space.World);
            rotate--;
        }
    }
}
