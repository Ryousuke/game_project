using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPlayer : MonoBehaviour
{
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        door = GameObject.Find("Door_Middle");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Door_Middle")
        {
            door.GetComponent<DoorOpen>().DoorMove();
        }
    }
}
