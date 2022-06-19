using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private HandGripController lHand, rHand;
    [SerializeField] private Ring ring;
    [SerializeField] private TrackingController cameraRig;
    [SerializeField] private FingerController fController;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.A))
        // {
        //     cameraRig.ResetHeight();
        // }

        // if (Input.GetKeyDown(KeyCode.A))
        if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))
        {
            fController.grabL = true;
        }
        else if (OVRInput.GetUp(OVRInput.RawButton.LHandTrigger))
        // else if (Input.GetKeyUp(KeyCode.A))
        {
            fController.grabL = false;
        }

        if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger))
        {
            fController.grabR = true;
        }
        else if (OVRInput.GetUp(OVRInput.RawButton.RHandTrigger))
        {
            fController.grabR = false;
        }

        if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
        // if (Input.GetKeyDown(KeyCode.A))
        {
            ring.FlameOn();
        }
        else if (OVRInput.GetUp(OVRInput.RawButton.LIndexTrigger))
        // else if (Input.GetKeyUp(KeyCode.A))
        {
            ring.FlameOff();
        }

        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            cameraRig.ResetAll();
        }
    }
}
