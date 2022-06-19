using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGripController : MonoBehaviour
{
    private List<Transform> fingers;
    private Transform thum;

    public bool targetState = false;
    public bool currentState = false;
    public bool isRunning { get { return targetState != currentState; } }

    // Start is called before the first frame update
    void Start()
    {
        fingers = new List<Transform>();

        foreach (Transform child in transform)
        {
            fingers.Add(child);
        }

        thum = fingers[4];
        fingers.RemoveAt(4);

        // Debug.Log(fingers.Count);
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            var curRot = fingers[0].eulerAngles.z;
            var targetRot = targetState ? 90 : 0;
            var diffRot = targetRot - curRot;
            var newRot = curRot + diffRot * 0.1f;

            foreach (var finger in fingers)
            {

                if (Mathf.Abs(diffRot) < 1)
                {
                    currentState = targetState;
                    break;
                }

                finger.localEulerAngles = new Vector3(0, 0, newRot);
                finger.GetChild(0).localEulerAngles = new Vector3(0, 0, newRot);
                finger.GetChild(0).GetChild(0).localEulerAngles = new Vector3(0, 0, newRot);
            }

            thum.GetChild(0).localEulerAngles = new Vector3(0, -newRot, 0);
            thum.GetChild(0).GetChild(0).localEulerAngles = new Vector3(0, -newRot, 0);
        }
    }

    // private void LateUpdate()
    // {
    //     fingers[0].localEulerAngles = new Vector3(0, 0, 90);
    // }
}
