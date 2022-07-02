using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour
{
    public bool isRight = true;

    public FingerData fingerData
    {
        get
        {
            return targetObject ? targetObject.FingerData : null;
        }
    }

    private List<HoldableObject> holdableStack = new List<HoldableObject>();
    private HoldableObject targetObject;

    public bool OnStartHold()
    {
        if (targetObject == null && holdableStack.Count > 0)
        {
            holdableStack[0].StartHold(this);
            targetObject = holdableStack[0];

            return true;
        }

        return false;
    }

    public bool OnEndHold()
    {
        if (targetObject != null)
        {
            targetObject.EndHold();
            targetObject = null;

            return true;
        }

        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<HoldableObject>() != null)
        {
            var tmp = other.GetComponent<HoldableObject>();
            if (!holdableStack.Exists(holdable => holdable == tmp))
            {
                Debug.Log("add holdable: " + other.name);
                holdableStack.Add(tmp);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<HoldableObject>() != null)
        {
            var tmp = other.GetComponent<HoldableObject>();
            if (holdableStack.Exists(holdable => holdable == tmp))
            {
                holdableStack.Remove(tmp);
            }
        }
    }
}
