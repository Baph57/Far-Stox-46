using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class HumanController : MonoBehaviour
{
    //x-axis
    [Tooltip("In Meters")] [SerializeField] float maxAllowedXPlaneTravel = 10f;
    [Tooltip("In Meters/Second (ms^-1)")][SerializeField] float xPlaneSpeed = 30f;

    //y-axis
    [Tooltip("In Meters/Second (ms^-1)")] [SerializeField] float yPlaneSpeed = 20f;
    [Tooltip("In Meters")] [SerializeField] float maxAllowedYPlaneTravel = 7f;

    [SerializeField] float positionPitchFactor = -5f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //processing translation (movement)
        HorizontalMovementController();
        VerticalMovementController();

        //processing rotation
        ProcessingRotationMovement();
    }

    private void HorizontalMovementController()
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

        //current xpos vs desired offset
        float rawDesiredNewXPosition = transform.localPosition.x + xOffsetOfCurrentFrame;


        float clampedNewXPosition = Mathf.Clamp
            (
            rawDesiredNewXPosition, //raw data that we are clamping
            -maxAllowedXPlaneTravel,//minimal amount of travel allowed (left)
            maxAllowedXPlaneTravel // maximum amount of travel allowed (right)
            );



        //transform is globally available, refers to attached object
        transform.localPosition = new Vector3
            (
            clampedNewXPosition,//X axis of vector, what we want to manipulate
            transform.localPosition.y,//this essentially leaves the y position the same
            transform.localPosition.z//this also leaves z position the same
            );
    }

    private void VerticalMovementController()
    {
        //cross platform refers to axis' rather than specific keys
        //we import this using Standard Assets
        //"Throw" implies the amount of distance the joystick has travelled from genesis
        float yPlaneThrow = CrossPlatformInputManager.GetAxis("Vertical");
        //throw implies force we are applying using input controls

        //We take Throw(Amount of force applied)
        //Speed(How fast the plane moves)
        //DeltaTime(If the frame took longer, the delta time would be higher and make you move farther
        //and finally we have the amount of X-Plane Units to move per frame
        float yOffsetOfCurrentFrame = yPlaneThrow * yPlaneSpeed * Time.deltaTime;

        //current xpos vs desired offset
        float rawDesiredNewYPosition = transform.localPosition.y + yOffsetOfCurrentFrame;


        float clampedNewYPosition = Mathf.Clamp
            (
            rawDesiredNewYPosition, //raw data that we are clamping
            -maxAllowedYPlaneTravel,//minimal amount of travel allowed (left)
            maxAllowedYPlaneTravel // maximum amount of travel allowed (right)
            );



        //transform is globally available, refers to attached object
        transform.localPosition = new Vector3
            (
            transform.localPosition.x,//this essentially leaves the x position the same
            clampedNewYPosition,//Y axis of vector, what we want to manipulate
            transform.localPosition.z//this also leaves z position the same
            );
    }

    private void ProcessingRotationMovement()
    {
        float pitch = transform.localPosition.y * positionPitchFactor;
        float yaw=0f;
        float roll=0f;

        //order of rotation maters!!!!
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
