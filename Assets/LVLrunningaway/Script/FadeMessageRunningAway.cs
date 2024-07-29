

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeMessageRunningAway : MonoBehaviour
{

    public float fadeTime = 3f;
    public TextMeshProUGUI textMeshProUGUI;
    private float alphaValue;
    private float fadePerSecond;

    // Start is called before the first frame update
    void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        fadePerSecond = 1 / fadeTime;
        alphaValue = textMeshProUGUI.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeTime > 0)
        {
            alphaValue -= fadePerSecond * Time.deltaTime;
            textMeshProUGUI.color = new Color(textMeshProUGUI.color.r, textMeshProUGUI.color.g, textMeshProUGUI.color.b, alphaValue);
            fadeTime -= Time.deltaTime;
        }
    }
}
