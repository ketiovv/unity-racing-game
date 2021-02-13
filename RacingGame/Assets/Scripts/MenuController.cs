using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Dropdown PlayersNumberDropdown;
    public Dropdown AttemptsNumberDropdown;

    public void Settings() => SceneManager.LoadScene(6);
    public void PlayTimeTrial()
    {
        LapTimeManager.ResetTimer();
        SceneManager.LoadScene(TrackChooseManager.CurrentTrack == Track.Asphalt ? 1 : 7);
    }

    public void About() => SceneManager.LoadScene(2);
    public void HotSeatSettings() => SceneManager.LoadScene(3);
    public void PlayHotSeat()
    {
        LapTimeManager.ResetTimer();
        var selectedPlayersNumberIndex = PlayersNumberDropdown.value;
        var selectedAttemptNumberIndex = AttemptsNumberDropdown.value;
        HotSeatManager.AttemptsOnStart = int.Parse(AttemptsNumberDropdown.options[selectedAttemptNumberIndex].text);
        HotSeatManager.PlayersNumber = int.Parse(PlayersNumberDropdown.options[selectedPlayersNumberIndex].text);
        HotSeatManager.InitializePlayers();
        SceneManager.LoadScene(4);
    }

    public void MainMenu() => SceneManager.LoadScene(0);

    public void Quit() => Application.Quit();
}
