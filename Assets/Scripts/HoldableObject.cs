using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldableObject : MonoBehaviour
{
    [SerializeField] private Vector3 position;
    [SerializeField] private Vector3 rotation;
    [SerializeField] private FingerData fingerData;

    [SerializeField] private Collider targetCollider;

    public bool IsHolding { get { return state != HoldState.Free; } }

    public Vector3 Position { get { return Position; } }
    public Vector3 Rotation { get { return Rotation; } }
    public FingerData FingerData { get { return FingerData; } }

    private enum HoldState
    {
        Free,
        Moving,
        Holding,
    }

    private HoldState state = HoldState.Free;

    private void Update()
    {
        if (state == HoldState.Moving)
        {
            // TODO: 左右をどうするか考える。のと係数は後ほど調整
            transform.localPosition = Vector3.Lerp(transform.localPosition, Position, Time.deltaTime);
            transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, Rotation, Time.deltaTime);

            var diff = transform.localPosition.magnitude - Position.magnitude;
            if (diff < 0.1f)
            {
                state = HoldState.Holding;
            }
        }
    }

    public void StartHold(Holder holder)
    {
        state = HoldState.Moving;
        transform.parent = holder.transform;

        GetComponent<Rigidbody>().useGravity = false;

        targetCollider.enabled = false;
    }

    public void EndHold()
    {
        state = HoldState.Free;
        transform.parent = null;

        GetComponent<Rigidbody>().useGravity = true;

        targetCollider.enabled = true;
    }
}
