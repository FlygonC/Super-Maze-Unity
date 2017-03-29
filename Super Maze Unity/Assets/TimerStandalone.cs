using UnityEngine;
using System.Collections;

public struct ClockTime
{
    public int frames;
    public int seconds;
    public int minuets;

    public ClockTime(int _frames, int _seconds, int _minutes)
    {
        frames = _frames;
        seconds = _seconds;
        minuets = _minutes;
    }
}

public class TimerStandalone {

    private int totalTime = 0;// in frames

    public ClockTime time
    {
        get
        {
            int newframes = totalTime;
            int newSeconds = 0;
            int newMins = 0;
            while (newframes > 60 * 60)
            {
                newMins++;
                newframes -= 60 * 60;
            }
            while (newframes > 60)
            {
                newSeconds++;
                newframes -= 60;
            }
            //frames = newframes;
            //seconds = newSeconds;
            //minuets = newMins;
            return new ClockTime(newframes, newSeconds, newMins);
        }
    }

    public void RunTime()
    {
        totalTime++;
    }

    public void Reset()
    {
        totalTime = 0;
    }

}
