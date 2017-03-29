using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    public int totalTime = 0;// in frames

    public int frames = 0;
    public int seconds = 0;
    public int minuets = 0;

    public ClockTime clockTime
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
            return new ClockTime(newframes, newSeconds, newMins);
        }
    }


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        totalTime++;

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
        frames = newframes;
        seconds = newSeconds;
        minuets = newMins;
	}
}
