using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    public int avgFrameRate;
    public string display_Text;

    private float interval = 0.5f;

    private float lastTime = 0;
    GUIStyle style = new GUIStyle();
    private void Start()
    {
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = Screen.height * 3 / 100;
        style.normal.textColor = new Color32(0, 200, 0, 255);
        
    }

    public void Update()
    {
        float current = 0;
        current = (int)(1f / Time.unscaledDeltaTime);
        if(Time.time-lastTime > interval)
        {
            avgFrameRate = (int)current;
            display_Text = avgFrameRate.ToString() + " FPS";
            lastTime = Time.time;
        }


    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 600, 600), display_Text,style);
    }
}

