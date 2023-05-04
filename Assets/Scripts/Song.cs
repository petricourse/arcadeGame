using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Song", order = 1)]
public class Song : ScriptableObject
{
    public float bpm;
    public AudioClip baseLoop;
    public int baseLoopBeats;

    //Not technically time signature, just the TOP NUMBER of the time signature
    public int timeSignature;

    int gridWidth;
    int gridHeight;

    public SongPhase[] phases;
}
