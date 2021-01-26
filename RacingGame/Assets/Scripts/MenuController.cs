using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Dropdown PlayersNumberDropdown;
    public Dropdown AttemptsNumberDropdown;

    public void PlayTimeTrial() => SceneManager.LoadScene(1);
    public void About() => SceneManager.LoadScene(2);
    public void HotSeatSettings() => SceneManager.LoadScene(3);
    public void PlayHotSeat()
    {
        var selectedPlayersNumberIndex = PlayersNumberDropdown.value;
        var selectedAttemptNumberIndex = AttemptsNumberDropdown.value;
        HotSeatManager.AttemptsOnStart = int.Parse(AttemptsNumberDropdown.options[selectedAttemptNumberIndex].text);
        HotSeatManager.PlayersNumber = int.Parse(PlayersNumberDropdown.options[selectedPlayersNumberIndex].text);
        SceneManager.LoadScene(4);
    }

    public void MainMenu() => SceneManager.LoadScene(0);
}
