
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManagerNightmareCatcher : MonoBehaviour
{
    public Button nextScene;
    public Button previousScene;
    public Button resumeGame;
    public Button easy;
    public Button medium;
    public Button hard;

    private bool difficultyButtonWasClicled = false;
    private Instantiation instance;
    public GameObject menuPanel;

    // Start is called before the first frame update
    void Start()
    {
        instance = GameObject.Find("Game Manager").GetComponent<Instantiation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            Menu();
            instance.StopInvoke();
        }
    }

    public void LoadNextScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LVLdreamCatcher");
    }

    public void LoadPreviousScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainRoom");
    }

    public void Menu()
    {
            menuPanel.SetActive(true);
            Time.timeScale = 0f;
    }

    public void Resume()
    {
        if (!difficultyButtonWasClicled)
        {
            instance.StartInvoke(1f, 1f);
        }
        menuPanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Easy() 
    {
        difficultyButtonWasClicled = true;
        instance.StartInvoke(1f, 1f);
    }

    public void Medium()
    {
        difficultyButtonWasClicled = true;
        instance.StartInvoke(1f, 0.7f);
    }

    public void Hard()
    {
        difficultyButtonWasClicled = true;
        instance.StartInvoke(0.7f, 0.5f);
    }
}