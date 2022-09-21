using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    [SerializeField] GameObject _pauseMenu;
    private bool _paused = false;


    private void FixedUpdate()
    {
        


    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Resume();

        }
        else if (Input.GetKey(KeyCode.Escape))
        {

            Pause();

        }

        if(Input.GetKey(KeyCode.H))
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SampleScene") && _paused == true)
            {
                Home(4);
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(5))
            {
                Home(4);
            }
        }
    }

    // Start is called before the first frame update
    public void Pause()
    {
        

        Time.timeScale = 0f;
        _pauseMenu.SetActive(true);
        _paused = true;
    }

    public void Resume()
    {
        

        Time.timeScale = 1f;
        _pauseMenu.SetActive(false);
        _paused = false;
    }

    public void Home(int sceneID)
    {
        _pauseMenu.SetActive(true);

        Time.timeScale = 1f;
        _paused = false;
        SceneManager.LoadScene(sceneID);
       
    }
}
