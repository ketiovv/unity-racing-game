using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayTimeTrial() => SceneManager.LoadScene(1);
    public void About() => SceneManager.LoadScene(2);
    public void HotSeatSettings() => SceneManager.LoadScene(3);
    public void PlayHotSeat() => SceneManager.LoadScene(4);
    public void MainMenu() => SceneManager.LoadScene(0);
}
