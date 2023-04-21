using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Song", order = 1)]
public class Song : ScriptableObject
{
    public float bpm;
    public AudioClip baseLoop;
    public int baseLoopBeats;

    int gridWidth;
    int gridHeight;

    public SongPhase[] phases;
}
