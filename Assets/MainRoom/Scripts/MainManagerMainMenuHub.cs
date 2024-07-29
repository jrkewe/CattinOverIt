using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using Unity.VisualScripting;

public class MainManagerMenuHub : MonoBehaviour
{
    public Button MainRoomButton;
    public Button cinematicButton;
    public Button LVLrunningawayButton;
    public Button LVLdreamCatcherButton;
    public Button quit;

    public GameObject pauseScreen;
    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        MainRoomButton.onClick.AddListener(LoadMainRoom);
        cinematicButton.onClick.AddListener(LoadCinematic);
        LVLrunningawayButton.onClick.AddListener(LoadLVLrunningawayScene);
        LVLdreamCatcherButton.onClick.AddListener(LoadLVLdreamCatcher);
        quit.onClick.AddListener(Exit);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangePaused();
        }
    }

    public void LoadCinematic()
    {
        print("TEST");
        SceneManager.LoadScene("IntroCinematic");
    }

    public void LoadMainRoom()
    {
        SceneManager.LoadScene("MainRoom");
    }

    public void LoadLVLrunningawayScene()
    {
        SceneManager.LoadScene("LVLrunningaway");
    }
    public void LoadLVLdreamCatcher()
    {
        SceneManager.LoadScene("LVLdreamCatcher");
    }

    public void Exit()
    {
        Application.Quit();
        //EditorApplication.ExitPlaymode(); // ONLY IN EDITOR MODE
    }

    void ChangePaused()
    {
        if (!isPaused)
        {
            isPaused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (isPaused)
        {
            isPaused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
}
