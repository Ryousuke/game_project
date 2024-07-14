using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeEnding : MonoBehaviour
{
    [SerializeField] private string SceneName; //遷移先のScene名の割り当て
    
    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {

        if(other.gameObject.name == "Exit")
        {
            SceneManager.LoadScene(SceneName);
        }

    }

}
