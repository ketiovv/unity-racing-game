using UnityEngine;
using UnityEngine.UI;

public class FinishCheckpointTrigger : MonoBehaviour
{
    public GameObject FinishCheckpointTrig;
    public GameObject Sector2CheckpointTrig;

    public GameObject LastLapMiliSeconds;
    public GameObject LastLapSeconds;
    public GameObject LastLapMinutes;

    public GameObject BestLapMiliSeconds;
    public GameObject BestLapSeconds;
    public GameObject BestLapMinutes;

    void OnTriggerEnter()
    {
        if (LapTimeManager.MinuteCount <= 9)
        {
            LastLapMinutes.GetComponent<Text>().text = "0" + LapTimeManager.MinuteCount + ":";
        }
        else
        {
            LastLapMinutes.GetComponent<Text>().text = "" + LapTimeManager.MinuteCount + ":";
        }

        if (LapTimeManager.SecondCount <= 9)
        {
            LastLapSeconds.GetComponent<Text>().text = "0" + LapTimeManager.SecondCount + ".";
        }
        else
        {
            LastLapSeconds.GetComponent<Text>().text = "" + LapTimeManager.SecondCount + ".";
        }

        LastLapMiliSeconds.GetComponent<Text>().text = "" + LapTimeManager.MiliSecondCount;


        var bestLapMinutes = int.Parse(BestLapMinutes.GetComponent<Text>().text.Trim(':', '.'));
        var bestLapSeconds = int.Parse(BestLapSeconds.GetComponent<Text>().text.Trim(':', '.'));
        //when milisecond is 9.6352 we get only 9
        var bestLapMiliSeconds = int.Parse(BestLapMiliSeconds.GetComponent<Text>().text.Substring(0, 1));

        if (bestLapMinutes == 0 && bestLapSeconds == 0 && bestLapMiliSeconds == 0)
        {
            UpdateBestLapTime();
        }
        else
        {
            if (LapTimeManager.MinuteCount < bestLapMinutes)
            {
                UpdateBestLapTime();
            }
            else if (LapTimeManager.MinuteCount == bestLapMinutes)
            {
                if (LapTimeManager.SecondCount < bestLapSeconds)
                {
                    UpdateBestLapTime();
                }
                else if (LapTimeManager.SecondCount == bestLapSeconds)
                {
                    if (LapTimeManager.MiliSecondCount < bestLapMiliSeconds)
                    {
                        UpdateBestLapTime();
                    }
                }

            }
        }

        // CLEAR TIME IN LAP TIME MANAGER
        LapTimeManager.MinuteCount = 0;
        LapTimeManager.SecondCount = 0;
        LapTimeManager.MiliSecondCount = 0;

        // UPDATE TRIGGERS
        FinishCheckpointTrig.SetActive(false);
        Sector2CheckpointTrig.SetActive(true);
    }

    void UpdateBestLapTime()
    {
        if (LapTimeManager.MinuteCount <= 9)
        {
            BestLapMinutes.GetComponent<Text>().text = "0" + LapTimeManager.MinuteCount + ":";
        }
        else
        {
            BestLapMinutes.GetComponent<Text>().text = "" + LapTimeManager.MinuteCount + ":";
        }

        if (LapTimeManager.SecondCount <= 9)
        {
            BestLapSeconds.GetComponent<Text>().text = "0" + LapTimeManager.SecondCount + ".";
        }
        else
        {
            BestLapSeconds.GetComponent<Text>().text = "" + LapTimeManager.SecondCount + ".";
        }

        BestLapMiliSeconds.GetComponent<Text>().text = "" + LapTimeManager.MiliSecondCount;
    }

}
