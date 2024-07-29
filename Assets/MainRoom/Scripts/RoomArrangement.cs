using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script attached to room object

public class RoomArrangement : MonoBehaviour
{
    public bool canChangeRoom=false;

    private SpriteRenderer _renderer;

    //////0-dirty / 1-medium / 2-clean
    private int roomState = 0;

    private DataPersistanceManager dataPersistanceManagerScript;

    [SerializeField] private Sprite mediumSprite;

    [SerializeField] private Sprite cleanSprite;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        //Search for 
        dataPersistanceManagerScript = GameObject.Find("Data Persistance Manager").GetComponent<DataPersistanceManager>();
        if (dataPersistanceManagerScript.roomChangementRunningAway)
        {
            roomState += 1;
        }
        if (dataPersistanceManagerScript.roomChangementDreamCatcher)
        {
            roomState += 1;
        }
        ChangeRoomDecoration();
    }

    public void ChangeRoomDecoration() 
    {
        /*
        switch (roomState)
        {
            case 0:
                //Trigger changement
                _renderer.sprite = mediumSprite;
                roomState = 1;
                break;
            case 1:
                //Trigger changement
                _renderer.sprite = cleanSprite;
                roomState = 2;
                break;
            default:
                break;
        }
        */
    }
}
