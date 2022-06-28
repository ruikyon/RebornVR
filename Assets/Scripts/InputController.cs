using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private HandGripController lHand, rHand;
    [SerializeField] private Ring ring;
    [SerializeField] private TrackingController cameraRig;
    [SerializeField] private FingerController fController;
    [SerializeField] private FingerData[] fingerDatas;
    [SerializeField] private Holder lHolder, rHolder;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.A))
        if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))
        {
            fController.lFingerData = fingerDatas[1];
        }
        else if (OVRInput.GetUp(OVRInput.RawButton.LHandTrigger))
        // else if (Input.GetKeyUp(KeyCode.A))
        {
            fController.lFingerData = fingerDatas[0];
        }

        // if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger))
        // {
        //     fController.rFingerData = fingerDatas[1];
        // }
        // else if (OVRInput.GetUp(OVRInput.RawButton.RHandTrigger))
        // {
        //     fController.rFingerData = fingerDatas[0];
        // }

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

        if (Input.GetKeyDown(KeyCode.R))
        {
            rHolder.OnStartHold();
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            rHolder.OnEndHold();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            lHolder.OnStartHold();
        }
        else if (Input.GetKeyUp(KeyCode.T))
        {
            lHolder.OnEndHold();
        }
    }
}
