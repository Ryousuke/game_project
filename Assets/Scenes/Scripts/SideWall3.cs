using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWall3 : MonoBehaviour
{
    Transform myTransform;
    Vector3 position_start;
    Vector3 position_now;

    float waitTime;
    bool back = false;
    bool stop = false;


    // Start is called before the first frame update
    void Start()
    {
        myTransform = this.transform;
        position_start = myTransform.position;
        position_now = position_start;
        waitTime = 0.25f;
    }

    // Update is called once per frame
    void Update()
    {
        if (stop)
        {
            return;
        }
        if (!back)
        {
            position_now.z -= 0.15f;
            if (position_start.z - position_now.z >= 4f)
            {
                back = true;
                StartCoroutine(Wait());
            }
        }
        else
        {
            position_now.z += 0.15f;
            if (position_start.z - position_now.z <= 0f)
            {
                back = false;
                StartCoroutine(Wait());
            }
        }


        myTransform.position = position_now;
    }
    protected IEnumerator Wait()
    {
        stop = true;
        yield return new WaitForSeconds(waitTime);
        stop = false;
    }
}
