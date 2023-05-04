using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseCreator : MonoBehaviour
{
    public Song currentSong;

    public RhythmManager rhythmManager;
       
    public PhaseType[,,] createPhase(int gridWidth, int gridHeight, SongPhase phase) {
        PhaseType[,,] phaseArr = new PhaseType[gridWidth, gridHeight, phase.numLoops * rhythmManager.currentSong.baseLoopBeats];

        for (int i = 0; i < phaseArr.GetLength(2); i++) {
            phaseArr[0, 0, i] = PhaseType.ERASER_PHASE;
            if (i % currentSong.timeSignature == 0) {
                phaseArr[2, 0, i] = PhaseType.ERASER_PHASE;
            }
        }

        return phaseArr;
    }
}
