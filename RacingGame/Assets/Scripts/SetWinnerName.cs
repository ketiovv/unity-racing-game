using UnityEngine;
using UnityEngine.UI;

public class SetWinnerName : MonoBehaviour
{
    public GameObject WinnerName;

    void Update()
    {
        WinnerName.GetComponent<Text>().text = HotSeatManager.PlayerWithBestTime.Name;
    }
}
