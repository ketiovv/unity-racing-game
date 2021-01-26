using Boo.Lang;
using System;
using UnityEngine;
using UnityEngine.UI;

public class HotSeatManager : MonoBehaviour
{
    public class HotSeatPlayer
    {
        public string Name { get; set; }
        public int Attempts { get; set; }
        public TimeSpan BestTime { get; set; }
    }

    public GameObject CurrentPlayerName;

    public static HotSeatPlayer Player1;
    public GameObject Player1Name;
    public GameObject Player1BestTime;
    public GameObject Player1Attempts;

    public static HotSeatPlayer Player2;
    public GameObject Player2Name;
    public GameObject Player2BestTime;
    public GameObject Player2Attempts;

    public static HotSeatPlayer Player3;
    public GameObject Player3Name;
    public GameObject Player3BestTime;
    public GameObject Player3Attempts;

    public static HotSeatPlayer Player4;
    public GameObject Player4Name;
    public GameObject Player4BestTime;
    public GameObject Player4Attempts;

    public static List<HotSeatPlayer> AllPlayers = new List<HotSeatPlayer>();


    public static int AttemptsOnStart = 3;
    public static int PlayersNumber = 2;

    public static HotSeatPlayer CurrentPlayer;
    public static HotSeatPlayer PlayerWithBestTime = null;

    void Start()
    {
        Player1 = new HotSeatPlayer()
        {
            Name = "Player #1",
            Attempts = AttemptsOnStart,
            BestTime = TimeSpan.Zero
        };
        Player2 = new HotSeatPlayer()
        {
            Name = "Player #2",
            Attempts = AttemptsOnStart,
            BestTime = TimeSpan.Zero
        };
        Player3 = new HotSeatPlayer()
        {
            Name = "Player #3",
            Attempts = AttemptsOnStart,
            BestTime = TimeSpan.Zero
        };
        Player4 = new HotSeatPlayer()
        {
            Name = "Player #4",
            Attempts = AttemptsOnStart,
            BestTime = TimeSpan.Zero
        };

        AllPlayers.Add(Player1);
        AllPlayers.Add(Player2);
        if (PlayersNumber >= 3) AllPlayers.Add(Player3);
        if (PlayersNumber >= 4) AllPlayers.Add(Player4);

        CurrentPlayer = Player1;
    }

    void Update()
    {
        CurrentPlayerName.GetComponent<Text>().text = CurrentPlayer.Name;

        Player1Name.GetComponent<Text>().text = Player1.Name;
        Player1BestTime.GetComponent<Text>().text = Player1.BestTime.ToString("g").Substring(3);
        Player1Attempts.GetComponent<Text>().text = Player1.Attempts > -1 ? Player1.Attempts.ToString() : "eliminated";

        Player2Name.GetComponent<Text>().text = Player2.Name;
        Player2BestTime.GetComponent<Text>().text = Player2.BestTime.ToString("g").Substring(3);
        Player2Attempts.GetComponent<Text>().text = Player2.Attempts > -1 ? Player2.Attempts.ToString() : "eliminated";

        if (PlayersNumber >= 3)
        {
            Player3Name.GetComponent<Text>().text = Player3.Name;
            Player3BestTime.GetComponent<Text>().text = Player3.BestTime.ToString("g").Substring(3);
            Player3Attempts.GetComponent<Text>().text = Player3.Attempts > -1 ? Player3.Attempts.ToString() : "eliminated";

        }

        if (PlayersNumber >= 4)
        {
            Player4Name.GetComponent<Text>().text = Player4.Name;
            Player4BestTime.GetComponent<Text>().text = Player4.BestTime.ToString("g").Substring(3);
            Player4Attempts.GetComponent<Text>().text = Player4.Attempts > -1 ? Player4.Attempts.ToString() : "eliminated";
        }
    }
}
