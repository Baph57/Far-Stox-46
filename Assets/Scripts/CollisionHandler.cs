using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //ok as long as this is the only component controlling scene

public class CollisionHandler : MonoBehaviour
{

    [Tooltip("In Seconds")][SerializeField] float levelLoadDelay = 2f;
    [Tooltip("FX Prefab")][SerializeField] GameObject DeathFX; //Serialized field expecting a GameObject called DeathFX
    
    private void OnTriggerEnter(Collider other)
    {
        print("whassap");
        DeathFX.SetActive(true);
        DeathConditionMet();
        Invoke("ReloadLevel", levelLoadDelay);
        //TODO: Start Death Sequence
    }

    private void DeathConditionMet()
    {
        SendMessage("DeathConditionWasMet");
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
