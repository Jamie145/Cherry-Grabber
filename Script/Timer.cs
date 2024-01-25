using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine.UI;
using UnityEngine;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text timerText;

    private static Stopwatch stopwatch = new Stopwatch();


    // Start is called before the first frame update
    void Start()
    {
        timerText = GameObject.Find("Time").GetComponent<Text>();

        if (timerText == null)
        {
            UnityEngine.Debug.LogError("The 'Time' Text component was not found. Make sure it's named 'Time' on the canvas.");
        }
        DontDestroyOnLoad(gameObject);
        
        stopwatch.Start();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimerDisplay();
    }

    void UpdateTimerDisplay() 
    {

        
        if (timerText != null)
        {
            TimeSpan elapsedTime = stopwatch.Elapsed;
            timerText.text = string.Format("{1:00}:{2:00}.{3:000}", elapsedTime.Hours, elapsedTime.Minutes, elapsedTime.Seconds, elapsedTime.Milliseconds);
        }
    }

    public void GameCompleted()
    {
        stopwatch.Stop();
    }

    public TimeSpan GetElapsedTime()
    {
        return stopwatch.Elapsed;
    }
}
