using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
     public GameObject CountDown;
    public GameObject LapTimer;
    public GameObject Car1;
    public GameObject Car2;
    private Rigidbody CarRigidbody;

    void Start()
    {
        if(CarChooseMenager.CurrentCar == Car.Sport)
        {
            CarRigidbody = Car1.GetComponent<Rigidbody>();
            Car2.SetActive(false);
        }
        else
        {
            CarRigidbody = Car2.GetComponent<Rigidbody>();
            Car1.SetActive(false);
        }
        StartCoroutine(CountStart());
    }

    public void Counting()
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
        CarRigidbody.isKinematic = false;
    }
}
