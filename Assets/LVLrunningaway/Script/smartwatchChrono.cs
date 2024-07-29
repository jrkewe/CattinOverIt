using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class TimerText : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Reference to the UI Text component
    private float totalTime = 90f; // Total time in seconds (1 minute 30 seconds)
    private float currentTime;

    void Start()
    {
        currentTime = totalTime;
        UpdateTimerText();
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            if (currentTime < 0)
            {
                currentTime = 0;
            }
            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        timerText.text = string.Format("{0:D2}\n{1:D2}", time.Minutes, time.Seconds);
    }
}
