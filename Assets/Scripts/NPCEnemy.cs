using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCEnemy : MonoBehaviour
{

    [SerializeField] GameObject DeathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 50;
    ScoreBoard scoreBoard; //instatitating an instance of our scoreboard class!



    // Start is called before the first frame update
    void Start()
    {
        AddBoxColliderOnRuntime();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddBoxColliderOnRuntime()
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

        //using an instance of ScoreBoard and assigning it to
        //FindObjectOfType, we essentially use the instance to grab
        //the actual scoreboard in the game!
        scoreBoard.ScoreHandler(scorePerHit);

        print("particles collided with enemy " + gameObject.name);
        Destroy(gameObject);
    }
}
