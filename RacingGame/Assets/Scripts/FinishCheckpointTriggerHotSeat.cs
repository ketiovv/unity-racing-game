using System;
using System.Linq;
using UnityEngine;

public class FinishCheckpointTriggerHotSeat : MonoBehaviour
{
    public GameObject Car;
    public Rigidbody CarRigidbody;

    public GameObject LapTimer;
    public GameObject CountdownManager;

    public GameObject FinishCheckpointTrig;
    public GameObject Sector2CheckpointTrig;

    void OnTriggerEnter()
    {
        // UPDATE TRIGGERS
        FinishCheckpointTrig.SetActive(false);
        Sector2CheckpointTrig.SetActive(true);

        // SET BEST TIME OF CURRENT PLAYER
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

        // STOP TIMER
        LapTimer.SetActive(false);

        // CHANGE PLAYER IF BETTER TIME
        if (HotSeatManager.PlayerWithBestTime == null)
        {
            HotSeatManager.PlayerWithBestTime = HotSeatManager.CurrentPlayer;
            HotSeatManager.CurrentPlayer = GetPlayerWithNoTime();
        }
        else if (CheckIfExistPlayerWithNoTime())
        {
            HotSeatManager.CurrentPlayer = GetPlayerWithNoTime();
        }
        else
        {
            if (HotSeatManager.PlayerWithBestTime.BestTime > timeInTimeStamp)
            {
                HotSeatManager.PlayerWithBestTime = HotSeatManager.CurrentPlayer;
                HotSeatManager.CurrentPlayer = GetPlayerWithWorstTime();
            }
            else
            {
                HotSeatManager.CurrentPlayer.Attempts--;
                if (HotSeatManager.CurrentPlayer.Attempts == -1)
                {
                    // ELIMINATE PLAYER WITH NO ATTEMPTS
                    HotSeatManager.AllPlayers.Remove(HotSeatManager.CurrentPlayer);
                    if (HotSeatManager.AllPlayers.Count > 1)
                    {
                        HotSeatManager.CurrentPlayer = GetPlayerWithWorstTime();
                    }
                    else
                    {
                        // END OF THE GAME
                    }
                }
            }
        }

        // RESET CAR POSITION

        // remove motion - probably unnecessary becouse of isKinematic
        CarRigidbody.velocity = Vector3.zero;
        CarRigidbody.angularVelocity = Vector3.zero;

        // physics does not affects the rigidbody
        CarRigidbody.isKinematic = true;

        // set default postion and rotation
        CarRigidbody.position = new Vector3(265.07f, 0.1f, 418.27f);
        CarRigidbody.rotation = Quaternion.Euler(0f, 35.628f, 0f);


        // start countdown
        var countdownScript = CountdownManager.GetComponent<Countdown>().CountStart();
        FinishCheckpointTrig.SetActive(true);
        StartCoroutine(countdownScript);
    }

    bool CheckIfExistPlayerWithNoTime()
    {
        return HotSeatManager.AllPlayers.Any(player => player.BestTime == TimeSpan.Zero);
    }

    HotSeatManager.HotSeatPlayer GetPlayerWithNoTime() =>
        HotSeatManager.AllPlayers.FirstOrDefault(player => player.BestTime == TimeSpan.Zero);

    HotSeatManager.HotSeatPlayer GetPlayerWithWorstTime()
    {
        HotSeatManager.HotSeatPlayer playerWithWorstTime = null;

        foreach (var player in HotSeatManager.AllPlayers)
        {
            if (playerWithWorstTime == null)
            {
                playerWithWorstTime = player;
            }
            else
            {
                if (playerWithWorstTime.BestTime < player.BestTime)
                {
                    playerWithWorstTime = player;
                }
            }
        }

        return playerWithWorstTime;
    }
}
