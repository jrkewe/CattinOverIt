using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script attached to room object

public class RoomArrangement : MonoBehaviour
{
    public bool canChangeRoom = false;

    //////0-dirty / 1-medium / 2-clean
    private int roomState;

    private DataPersistanceManager dataPersistanceManagerScript;


    private SpriteRenderer _renderer;
    [SerializeField] private Sprite mediumSprite;
    [SerializeField] private Sprite cleanSprite;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();

        dataPersistanceManagerScript = GameObject.Find("Data Persistance Manager").GetComponent<DataPersistanceManager>();
        canChangeRoom = dataPersistanceManagerScript.canChange;

        if (roomState >= 3){roomState = 2;}
        else{ roomState = dataPersistanceManagerScript.roomCount; }

        if (canChangeRoom)
        {
            ChangeRoomDecoration();
        }
    }

    public void ChangeRoomDecoration()
    {
        Debug.Log(roomState);
        switch (roomState)
        {
            case 1:
               _renderer.sprite = mediumSprite;
                roomState = 1;
                canChangeRoom = false;

                break;
            case 2:
               _renderer.sprite = cleanSprite;
                roomState = 2;
                canChangeRoom = false;

                break;
            default:
                break;
        }
    }
}
