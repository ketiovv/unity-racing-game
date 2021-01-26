using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class CarControlInactive : MonoBehaviour
{
    public GameObject CarControl;

    void Start()
    {
        CarControl.GetComponent<CarUserControl>().enabled = false;
    }
}
