using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class LapTimeManager : MonoBehaviour
{
    public static float MiliSecondCount;
    public static int SecondCount;
    public static int MinuteCount;
    public static string MiliSecondDisplay;

    public GameObject MinuteBox;
    public GameObject SecondBox;
    public GameObject MiliSecondBox;

    void Update()
    {
        // miliseconds
        MiliSecondCount += Time.deltaTime * 10;
        MiliSecondDisplay = MiliSecondCount.ToString("F0");
        MiliSecondBox.GetComponent<Text>().text = "" + MiliSecondDisplay;

        if (MiliSecondCount >= 10)
        {
            MiliSecondCount = 0;
            SecondCount += 1;
        }

        // seconds
        if (SecondCount <= 9)
        {
            SecondBox.GetComponent<Text>().text = "0" + SecondCount + ".";
        }
        else
        {
            SecondBox.GetComponent<Text>().text = "" + SecondCount + ".";
        }

        // minutes
        if (SecondCount >= 60)
        {
            SecondCount = 0;
            MinuteCount += 1;
        }

        if (MinuteCount <= 9)
        {
            MinuteBox.GetComponent<Text>().text = "0" + MinuteCount + ":";
        }
        else
        {
            MinuteBox.GetComponent<Text>().text = "" + MinuteCount + ":";
        }
    }
}
