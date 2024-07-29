using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class DataPersistanceManager : MonoBehaviour
{
    public static DataPersistanceManager Instance;

    public bool roomChangementDreamCatcher = false;
    public bool roomChangementRunningAway = false;

    public int roomCount = 0;
    public bool canChange = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
