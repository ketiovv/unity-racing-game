using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarChooseMenager : MonoBehaviour
{
    public static Car CurrentCar = Car.Rally;

    public void SetSportCar() => CurrentCar = Car.Sport;
    public void SetRallyCar() => CurrentCar = Car.Rally;

}

public enum Car
{
    Sport,
    Rally
}
