using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ChangeSceneButton : MonoBehaviour
{
    [SerializeField] private string SceneName; //遷移先のScene名の割り当て
    
    private void Start()
    {
        var button = GetComponent<Button>();
        //ボタンクリックで画面遷移
        button.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneName);
        });
    }

}
