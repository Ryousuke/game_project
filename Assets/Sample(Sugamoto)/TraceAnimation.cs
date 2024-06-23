using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceAnimation : MonoBehaviour
{
    private Vector3 position_now;
    private Vector3 position_pre;
    private float speed;    
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        position_pre = transform.position;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        position_now = transform.position;
        var deltaPosition = position_now - position_pre;
        speed = 1000*deltaPosition.magnitude;
        //Debug.Log(speed);
        //Debug.Log(deltaPosition);
        if(speed < 2)
        {
            //Debug.Log("Idle");
            anim.SetBool("Running", false);
        }
        else
        {
            //Debug.Log("Run");
            anim.SetBool("Running", true);
        }
        position_pre = position_now;
    }
}
