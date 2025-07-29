using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class AudioController : MonoBehaviour
{


    //Gets beats Per Min
    [SerializeField] private float bpm;
    [SerializeField] private int newBPM;
    [SerializeField] int foundAudio;
    [SerializeField] AudioResource bossMusic;
    // Gets The Audio source
    [SerializeField] private AudioSource audioSource;
    //
    [SerializeField] private Intervals[] intervals;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerStay(Collider other)
    {
        //Finds The boss or Spawner And Gets The music From it
        if (other.gameObject.layer == 21 && bossMusic == null)
        {
            bossMusic = other.gameObject.GetComponent<SpawnManager>().bossMusicGet;
            audioSource.resource = bossMusic;
           newBPM = other.gameObject.GetComponent<SpawnManager>().bossMusicBPM;
        }
    }

    private void Update()
    {
        //Checks to see if ther is a audio source If so Start the audio But only once.
        if (bossMusic != null && foundAudio <= 0)
        {
            //Sets the bpm to The Bpm Of the Spawned boss
            bpm = newBPM;
            audioSource.Play();
            foundAudio = 1;
        }

        if (bossMusic != null)
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