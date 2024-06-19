using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 鍵を取得した時の処理
            GameManager.Instance.KeyCollected();
            Destroy(gameObject); // 鍵オブジェクトを破壊
        }
    }
}
