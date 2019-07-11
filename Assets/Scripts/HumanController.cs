using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class HumanController : MonoBehaviour
{

    [Tooltip("In Meters/Second (ms^-1)")][SerializeField] float xPlaneSpeed = 4f;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //cross platform refers to axis' rather than specific keys
        //we import this using Standard Assets
        //"Throw" implies the amount of distance the joystick has travelled from genesis
        float xPlaneThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        //throw implies force we are applying using input controls

        //We take Throw(Amount of force applied)
        //Speed(How fast the plane moves)
        //DeltaTime(If the frame took longer, the delta time would be higher and make you move farther
        //and finally we have the amount of X-Plane Units to move per frame
        float xOffsetOfCurrentFrame = xPlaneThrow * xPlaneSpeed * Time.deltaTime;
        print(xOffsetOfCurrentFrame);
    }
}
