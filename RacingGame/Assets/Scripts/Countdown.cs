using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public GameObject CountDown;
    public GameObject LapTimer;
    public GameObject CarControls;
    public GameObject FinishCheckpoint;
    public Rigidbody CarRigidbody;

    void Start()
    {
        StartCoroutine(CountStart());
    }

    public IEnumerator CountStart()
    {
        yield return new WaitForSeconds(0.5f);
        CountDown.GetComponent<Text>().text = "3";
        CountDown.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown.SetActive(false);
        CountDown.GetComponent<Text>().text = "2";
        CountDown.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown.SetActive(false);
        CountDown.GetComponent<Text>().text = "1";
        CountDown.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown.SetActive(false);
        LapTimer.SetActive(true);
        FinishCheckpoint.SetActive(false);
        CarRigidbody.isKinematic = false;
        CarControls.SetActive(true);
    }
}
