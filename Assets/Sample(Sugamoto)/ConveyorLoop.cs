using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorLoop : MonoBehaviour
{
    Transform myTransform;
    [SerializeField] Transform loopTransform;
    private Vector3 position_reset;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        myTransform = this.transform;
        position_reset = loopTransform.position;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
    void OnCollisionExit(Collision other)
    {
        Debug.Log(other.transform.root.gameObject.name);
        if(other.transform.root.gameObject.name == "Floor")
        {
            myTransform.position = position_reset;
        }
    }
}
