using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControls : MonoBehaviour
{
    private void Start()
    {
        
    }
    public void SceneChanger(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
