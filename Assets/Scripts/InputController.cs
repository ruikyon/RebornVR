using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private HandGripController lHand, rHand;
    [SerializeField] private Ring ring;
    [SerializeField] private TrackingController cameraRig;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))
        {
            lHand.targetState = true;
        }
        else if (OVRInput.GetUp(OVRInput.RawButton.LHandTrigger))
        {
            lHand.targetState = false;
        }

        if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger))
        {
            rHand.targetState = true;
        }
        else if (OVRInput.GetUp(OVRInput.RawButton.LHandTrigger))
        {
            rHand.targetState = false;
        }

        if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
        {
            ring.FlameOn();
        }
        else if (OVRInput.GetUp(OVRInput.RawButton.LIndexTrigger))
        {
            ring.FlameOff();
        }

        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            cameraRig.ResetAll();
        }
    }
}
