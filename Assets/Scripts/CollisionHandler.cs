using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("whassap");
        DeathConditionMet();
        //TODO: Start Death Sequence
    }

    private void DeathConditionMet()
    {
        SendMessage("PrintDeath");
    }

}
