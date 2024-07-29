using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointSystem : MonoBehaviour
{
    private int points = 0;
    private int lives = 3;

    private GameObject player;

    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI livesText;

    private MainManagerNightmareCatcher MainManagerNightmareCatcher;

    private DataPersistanceManager dataPersistanceManagerScript;
    private Instantiation instantiationScript;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        pointsText.text = "Score: " + points;
        livesText.text = "Lives: " + lives;

        MainManagerNightmareCatcher = GameObject.Find("MainManager NightmareCatcher").GetComponent<MainManagerNightmareCatcher>();

        dataPersistanceManagerScript = GameObject.Find("Data Persistance Manager").GetComponent<DataPersistanceManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddPoint(int value) 
    {
        points+=value;
        if (points < 0)
        {
            pointsText.text = "Score: 0" ;
            Time.timeScale = 0f;
            MainManagerNightmareCatcher.Menu();
            return;
        } else if (points == 10) { // win condition
            dataPersistanceManagerScript.roomChangementDreamCatcher = true;
            Time.timeScale = 0f;
            MainManagerNightmareCatcher.Menu();
        }
        pointsText.text = "Score: " + points;
    }
    public void AddLive(int value) 
    {
        lives += value;
        if (lives<=0)
        {
            Destroy(player);
            Time.timeScale = 0f;
            livesText.text = "Lives: " + lives;
            MainManagerNightmareCatcher.Menu();
        }
        livesText.text = "Lives: " + lives;
    }
}
