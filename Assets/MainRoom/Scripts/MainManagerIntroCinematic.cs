using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManagerIntroCinematic : MonoBehaviour
{
    public Button MainMenuButton;
    public Button cinematicSceneButton;


    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton.onClick.AddListener(LoadMainMenu);
        cinematicSceneButton.onClick.AddListener(ReloadCinematic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMainMenu() 
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ReloadCinematic()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadPreviousScene()
    {

    }
}
