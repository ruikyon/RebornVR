using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour
{
    public FingerData fingerData
    {
        get
        {
            return targetObject ? targetObject.FingerData : null;
        }
    }

    private List<HoldableObject> holdableStack = new List<HoldableObject>();
    private HoldableObject targetObject;

    public void OnStartHold()
    {
        if (targetObject != null && holdableStack.Count > 0)
        {
            holdableStack[0].StartHold(this);
            targetObject = holdableStack[0];
        }
    }

    public void OnEndHold()
    {
        if (targetObject != null)
        {
            targetObject.EndHold();
            targetObject = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<HoldableObject>() != null)
        {
            var tmp = other.GetComponent<HoldableObject>();
            if (!holdableStack.Exists(holdable => holdable == tmp))
            {
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