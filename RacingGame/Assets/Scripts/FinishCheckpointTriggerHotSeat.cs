using System;
using UnityEngine;

public class FinishCheckpointTriggerHotSeat : MonoBehaviour
{
    public GameObject FinishCheckpointTrig;
    public GameObject Sector2CheckpointTrig;

    void OnTriggerEnter()
    {
        // SET BEST TIME OF PLAYER
        var timeInTimeStamp = new TimeSpan(0, 0,
            LapTimeManager.MinuteCount,
            LapTimeManager.SecondCount,
            int.Parse(LapTimeManager.MiliSecondDisplay) * 100);

        if (HotSeatManager.CurrentPlayer.BestTime == TimeSpan.Zero)
        {
            HotSeatManager.CurrentPlayer.BestTime = timeInTimeStamp;
        }
        else
        {
            if (HotSeatManager.CurrentPlayer.BestTime > timeInTimeStamp)
            {
                HotSeatManager.CurrentPlayer.BestTime = timeInTimeStamp;
            }
        }

        // CLEAR TIME IN LAP TIME MANAGER
        LapTimeManager.MinuteCount = 0;
        LapTimeManager.SecondCount = 0;
        LapTimeManager.MiliSecondCount = 0;

        // CHANGE PLAYER
        HotSeatManager.HotSeatPlayer playerWithBestTime = null;


        // UPDATE TRIGGERS
        FinishCheckpointTrig.SetActive(false);
        Sector2CheckpointTrig.SetActive(true);
    }

    void ChangePlayerForSecondOne()
    {
        if (HotSeatManager.CurrentPlayer == HotSeatManager.Player1)
        {
            HotSeatManager.CurrentPlayer = HotSeatManager.Player2;
        }
        else
        {
            HotSeatManager.CurrentPlayer = HotSeatManager.Player1;
        }
    }
}
