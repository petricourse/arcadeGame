using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SongPhase", order = 1)]
public class SongPhase : ScriptableObject
{
    public PhaseType type;
    public float difficulty;

    //In beats
    public int numLoops;
}
