using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector2CheckpointTrigger : MonoBehaviour
{
    public GameObject Sector2CheckpointTrig;
    public GameObject Sector3CheckpointTrig;

    void OnTriggerEnter()
    {
        Sector2CheckpointTrig.SetActive(false);
        Sector3CheckpointTrig.SetActive(true);
    }
}
