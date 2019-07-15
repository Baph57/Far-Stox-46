using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        print("particles collided with enemy " + gameObject.name);
        Destroy(gameObject);
    }
}
