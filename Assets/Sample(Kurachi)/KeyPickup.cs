using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // �����擾�������̏���
            GameManager.Instance.KeyCollected();
            Destroy(gameObject); // ���I�u�W�F�N�g��j��
        }
    }
}
