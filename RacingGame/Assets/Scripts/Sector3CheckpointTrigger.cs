using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector3CheckpointTrigger : MonoBehaviour
{
    public GameObject Sector3CheckpointTrig;
    public GameObject FinishCheckpointTrig;

    void OnTriggerEnter()
    {
        Sector3CheckpointTrig.SetActive(false);
        FinishCheckpointTrig.SetActive(true);
    }
}
