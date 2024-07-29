using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManagerMainRoom : MonoBehaviour
{
    public Button nextScene;
    public Button previousScene;

    public GameObject pauseScreen;
    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangePaused();
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("GameScene1");
    }

    public void LoadPreviousScene()
    {
        SceneManager.LoadScene("HubScene");
    }

    void ChangePaused() 
    {
        if (!isPaused) 
        {
            isPaused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        else if(isPaused)
        {
            isPaused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
}