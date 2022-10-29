using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class GameSceneResultPanel : MonoBehaviour
{
    [SerializeField] string _gameSceneName;
    [SerializeField] string _startSceneName;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("BackToTitle",10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(_gameSceneName);
        }
    }
    void BackToTitle() 
    {
        SceneManager.LoadScene(_startSceneName);
    }
}
