using UnityEngine;
using UnityEngine.Events;

public class AudioController : MonoBehaviour
{
    //Gets beats Per Min
    [SerializeField] private float bpm;
    // Gets The Audio source
    [SerializeField] private AudioSource audioSource;
    //
    [SerializeField] private Intervals[] intervals;


    private void Update()
    {
        //This is for tracking The time of the audio That has passed from Current Interval
        foreach (var interval in intervals)
        {
            float sampleTime = (audioSource.timeSamples / (audioSource.clip.frequency * interval.GetIntervalLength(bpm)));
            //This checks to see if the time For the Beat has Cross to a new beat by sending the time to the method
            interval.CheckForNewInterval(sampleTime);
        }
    }
}




[System.Serializable]
public class Intervals
{

    [SerializeField] public float steps;
    [SerializeField] private UnityEvent trigger;
                     private int lastInterval;

    //Gets The Beat Of The song we Are Tracking In the combat fight. 
    public float GetIntervalLength(float bpm)
    {

        //Getting Beats Per seconds 
        return 60f/(bpm* steps);
    }


    //Checks  To see If the current beat is pass the Audio beat, if it A new beat is likely.
    public void CheckForNewInterval(float interval)
    {
        if(Mathf.FloorToInt(interval) != lastInterval) {
        lastInterval = Mathf.FloorToInt(interval);
            //Allows Whatever Request on The Object to be Done.
            trigger.Invoke();
        }
    }
}