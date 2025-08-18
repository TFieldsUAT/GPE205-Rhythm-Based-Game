using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private int randomSong;
    public List<AudioResource> musicToPlay;

    private void Awake()
    {
        musicAudioSource = GetComponent<AudioSource>();
        ChangeTrack();
        musicAudioSource.Play();
    }


    public void ChangeTrack()
    {
        randomSong = Random.Range(0, musicToPlay.Count);

        musicAudioSource.resource = musicToPlay[randomSong];
        musicAudioSource.Play();

    }

}
