using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class HumanController : MonoBehaviour
{

    //TODO: Why is the speed not constant and seemingly changing?


    //cross platform refers to axis' rather than specific keys
    //we import this using Standard Assets
    //"Throw" implies the amount of distance the joystick has travelled from genesis

    //x-axis
    float xPlaneThrow;
    [Header("X-Plane")] //categorization in editor
    [Tooltip("In Meters")] [SerializeField] float maxAllowedXPlaneTravel = 10f;
    [Tooltip("In Meters/Second (ms^-1)")][SerializeField] float xPlaneSpeed = 30f;

    //y-axis
    float yPlaneThrow;
    [Header("Y-Plane")]
    [Tooltip("In Meters")] [SerializeField] float maxAllowedYPlaneTravel = 7f;
    [Tooltip("In Meters/Second (ms^-1)")] [SerializeField] float yPlaneSpeed = 20f;

    //Arithmetic Member Variables
    [Header("Screen vs. Position Based")]
    [SerializeField] float positionPitchFactor = -5f;//
    [SerializeField] float positionYawFactor = 5f;

    [Header("Control vs. Throw Based")]
    [SerializeField] float controlledPitchFactor = -20f;
    [SerializeField] float controlledRollFactor = -20f;


    [Header("Guns")]
    [SerializeField] GameObject[] Guns;


    bool isDeathConditionMet = false;

    // Start is called before the first frame update
    void Start()
    {
        //print();
    }

    void DeathConditionWasMet() //called by string-reference method
    {
        isDeathConditionMet = true;
        print("message has been sent!");
    }

    // Update is called once per frame
    void Update()
    {
        if (isDeathConditionMet == false)
        {
        //processing translation (movement)
        HorizontalMovementController();
        VerticalMovementController();

        //processing rotation
        ProcessingRotationMovement();

        //processing player firing
        ProccesingHumanFiring();
        }

    }

    private void HorizontalMovementController()
    {

    xPlaneThrow = CrossPlatformInputManager.GetAxis("Horizontal");

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
        yPlaneThrow = CrossPlatformInputManager.GetAxis("Vertical");


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
        float pitch =
            transform.localPosition.y *//current local y pos
            positionPitchFactor + //positionally how much to affect pitch
            yPlaneThrow * //our CrossPlatformManager that allows joysticks and keys
            controlledPitchFactor; //

        float yaw = transform.localPosition.x * positionYawFactor;
            
        float roll= xPlaneThrow * controlledRollFactor;

        //order of rotation maters!!!! 
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProccesingHumanFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            ProjectilesShouldFire(true);   
        }
        else
        {
            ProjectilesShouldFire(false);
        }
    }

    private void ProjectilesShouldFire(bool weShouldFire)
    {
        if (weShouldFire)
        {
            foreach(GameObject gun in Guns)
            {
                gun.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject gun in Guns)
            {
                gun.SetActive(false);
            }
        }
        //throw new NotImplementedException(); ?? 
    }
}
