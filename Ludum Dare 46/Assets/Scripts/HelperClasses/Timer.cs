using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool TimeElapsed { get; private set; }
    public float TimeLeft { get; private set; }
    private bool start;

    public void StartTimer(float seconds)
    {
        TimeElapsed = false;
        TimeLeft = seconds;
        start = true;
    }
    private void Update()
    {
        if (start)
        {
            TimeLeft -= Time.deltaTime;
            if (TimeLeft <= 0)
            {
                TimeElapsed = true;
                start = false;
            }
        }
    }
}
