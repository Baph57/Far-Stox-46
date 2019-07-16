using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCEnemy : MonoBehaviour
{

    [SerializeField] GameObject DeathFX;
    [SerializeField] Transform parent;

    
    // Start is called before the first frame update
    void Start()
    {

       //Collider npcBoxCollider = gameObject.AddComponent<BoxCollider>();
        //npcBoxCollider.isTrigger = true;

        //Ben is not a fan of this, calling it a 'side effect'
        //I find this to be innacurate and if it doesn't
        // introduce actual side effects, I'd rather leave it as one line
        gameObject.AddComponent<BoxCollider>().isTrigger = false;
    }

    //private void AddNonTriggerBoxCollider

    private void OnParticleCollision(GameObject other)
    {
        //Quaternion.identity here is simply saying we want no rotation
        //Or to set the rotation to the current quaterion identity
        GameObject Explosion = Instantiate(DeathFX, transform.position, Quaternion.identity);

        //this allows us to parent the deathFX to an empty game object
        Explosion.transform.parent = parent;

        print("particles collided with enemy " + gameObject.name);
        Destroy(gameObject);
    }
}
