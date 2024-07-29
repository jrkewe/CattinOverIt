using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class BPMText : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Reference to the UI Text component
    private float totalTime = 90f; // Total time in seconds (1 minute 30 seconds)
    private float currentTime;
    private float jitterInterval = 2f; // Interval to update jitter in seconds
    private float nextJitterTime; // Time to update the next jitter

    void Start()
    {
        currentTime = totalTime;
        UpdateTimerText();
    }

    void Update()
    { // 135 à 153 BPM
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
        // Update jitter every 2 second
        if (Time.time >= nextJitterTime)
        {
            int bpm = Mathf.FloorToInt(135 + 20 * ((totalTime - currentTime) / totalTime));
            bpm += UnityEngine.Random.Range(-5, 6); // Add random jitter between -5 and 5
            nextJitterTime = Time.time + jitterInterval;
            timerText.text = bpm.ToString();
        }
    }
}
