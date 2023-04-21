using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmManager : MonoBehaviour
{
    public AudioSource audioSource;

    public Song currentSong;

    public float secsPerBeat;
    public float loopPosTime;
    public float loopPosBeats;

    public float songStartTime;

    public bool playing = false;

    public void setSong(Song song)
    {
        secsPerBeat = 60f / song.bpm;
        currentSong = song;
        audioSource.clip = song.baseLoop;
    }

    public void playSong()
    {
        songStartTime = (float)AudioSettings.dspTime;
        playing = true;
        audioSource.Play();
    }

    public void stopSong()
    {
        playing = false;
    }

    void Update()
    {
        if (playing)
        {
            
            loopPosTime = (float)(AudioSettings.dspTime - songStartTime);
            loopPosBeats = loopPosTime / secsPerBeat;
            Debug.Log(loopPosBeats);
            if (loopPosBeats >= currentSong.baseLoopBeats)
            {
                loopPosBeats = 0;
                loopPosTime = 0;
                songStartTime = (float)AudioSettings.dspTime;
                audioSource.Play();
            }
        }
    }
}
