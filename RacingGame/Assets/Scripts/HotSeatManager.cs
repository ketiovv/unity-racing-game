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

    public GameObject Player1Name;
    public GameObject Player1BestTime;
    public GameObject Player1Attempts;

    public GameObject Player2Name;
    public GameObject Player2BestTime;
    public GameObject Player2Attempts;

    public GameObject Player3Name;
    public GameObject Player3BestTime;
    public GameObject Player3Attempts;

    public static int AttemptsOnStart = 3;

    public static HotSeatPlayer CurrentPlayer;
    public static HotSeatPlayer PlayerWithBestTime = null;

    public static HotSeatPlayer Player1;
    public static HotSeatPlayer Player2;
    public static HotSeatPlayer Player3;


    public static List<HotSeatPlayer> AllPlayers = new List<HotSeatPlayer>();


    void Start()
    {
        Player1 = new HotSeatPlayer()
        {
            Name = "Wojtek",
            Attempts = AttemptsOnStart,
            BestTime = TimeSpan.Zero
        };
        AllPlayers.Add(Player1);

        Player2 = new HotSeatPlayer()
        {
            Name = "Konrad",
            Attempts = AttemptsOnStart,
            BestTime = TimeSpan.Zero
        };
        AllPlayers.Add(Player2);

        Player3 = new HotSeatPlayer()
        {
            Name = "Martyna",
            Attempts = AttemptsOnStart,
            BestTime = TimeSpan.Zero
        };
        AllPlayers.Add(Player3);

        CurrentPlayer = Player1;
    }

    void Update()
    {
        CurrentPlayerName.GetComponent<Text>().text = CurrentPlayer.Name;

        Player1Name.GetComponent<Text>().text = Player1.Name;
        Player1BestTime.GetComponent<Text>().text = Player1.BestTime.ToString().Substring(3);
        Player1Attempts.GetComponent<Text>().text = Player1.Attempts > -1 ? Player1.Attempts.ToString() : "eliminated";

        Player2Name.GetComponent<Text>().text = Player2.Name;
        Player2BestTime.GetComponent<Text>().text = Player2.BestTime.ToString().Substring(3);
        Player2Attempts.GetComponent<Text>().text = Player2.Attempts > -1 ? Player2.Attempts.ToString() : "eliminated";

        Player3Name.GetComponent<Text>().text = Player3.Name;
        Player3BestTime.GetComponent<Text>().text = Player3.BestTime.ToString().Substring(3);
        Player3Attempts.GetComponent<Text>().text = Player3.Attempts > -1 ? Player3.Attempts.ToString() : "eliminated";
    }
}
