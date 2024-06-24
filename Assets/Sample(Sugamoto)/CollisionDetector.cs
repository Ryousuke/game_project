using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class CollisionDetector : MonoBehaviour
{

    [SerializeField] private TriggerEvent onTrigerStay = new TriggerEvent();

    private void OnTriggerStay(Collider other)
    {
        onTrigerStay.Invoke(other);
        //Debug.Log("Trigger");
    }

    [Serializable]
    public class TriggerEvent : UnityEvent<Collider>
    {
    }
}
