using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public MoveableWall wall; // ˆÚ“®‚·‚é•Ç

    public void KeyCollected()
    {
        wall.MoveWall();
    }
}
