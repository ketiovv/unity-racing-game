using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        // SET BEST TIME OF CURRENT PLAYER
        var timeInTimeStamp = new TimeSpan(0, 0,
            LapTimeManager.MinuteCount,
            LapTimeManager.SecondCount,
            (int)Math.Round(LapTimeManager.MiliSecondCount * 100));

        SetBestTimeOfCurrentPlayer(timeInTimeStamp);

        // CLEAR TIME IN LAP TIME MANAGER
        LapTimeManager.ResetTimer();

        // STOP TIMER
        LapTimer.SetActive(false);

        // CHANGE PLAYER IF BETTER TIME
        ChangeCurrentPlayerIfBetterTime(timeInTimeStamp);

        // RESET CAR POSITION
        ResetCarPosition();


        // UPDATE TRIGGERS
        FinishCheckpointTrig.SetActive(false);
        Sector2CheckpointTrig.SetActive(true);

        // START COUNTDOWN
        var countdownScript = CountdownManager.GetComponent<Countdown>();
        countdownScript.Counting();
        Debug.Log($"Best time: {HotSeatManager.PlayerWithBestTime.Name}");

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



    void SetBestTimeOfCurrentPlayer(TimeSpan timeInTimeStamp)
    {
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
    }
    void ChangeCurrentPlayerIfBetterTime(TimeSpan timeInTimeStamp)
    {
        if (HotSeatManager.PlayerWithBestTime == null)
        {
            HotSeatManager.PlayerWithBestTime = HotSeatManager.CurrentPlayer;
            HotSeatManager.CurrentPlayer = GetPlayerWithNoTime();
        }
        else if (CheckIfExistPlayerWithNoTime())
        {
            if (HotSeatManager.PlayerWithBestTime.BestTime > timeInTimeStamp)
            {
                HotSeatManager.PlayerWithBestTime = HotSeatManager.CurrentPlayer;
            }
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
                if (GetPlayerWithWorstTime() == HotSeatManager.CurrentPlayer)
                {
                    HotSeatManager.CurrentPlayer.Attempts--;
                }

                // ELIMINATE PLAYER WITH NO ATTEMPTS
                if (HotSeatManager.CurrentPlayer.Attempts == -1)
                {
                    HotSeatManager.AllPlayers.Remove(HotSeatManager.CurrentPlayer);
                    if (HotSeatManager.AllPlayers.Count == 1)
                    {
                        // IF ELIMINATE LAST ONE -> END THE GAME
                        SceneManager.LoadScene(5);
                    }
                }

                HotSeatManager.CurrentPlayer = GetPlayerWithWorstTime();
            }
        }
    }
    void ResetCarPosition()
    {
        // physics does not affects the rigidbody
        CarRigidbody.isKinematic = true;

        // set default postion and rotation
        CarRigidbody.position = new Vector3(265.07f, 0.1f, 418.27f);
        CarRigidbody.rotation = Quaternion.Euler(0f, 35.628f, 0f);
    }
}
