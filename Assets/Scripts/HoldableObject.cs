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

    public Vector3 Position { get { return position; } }
    public Vector3 Rotation { get { return rotation; } }
    public FingerData FingerData { get { return fingerData; } }

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
            // right -> left (box)
            // posX *= -1, rotZ -= 90
            transform.localPosition = Vector3.Lerp(transform.localPosition, Position, Time.deltaTime * 5);
            // transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, Rotation, Time.deltaTime);

            // var newRot = Quaternion.FromToRotation(transform.localEulerAngles, Rotation);
            // newRot.w *= Time.deltaTime;
            // transform.localRotation *= newRot;

            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(Rotation), Time.deltaTime * 5);

            var dx = (transform.localPosition.x - Position.x) / Position.x;
            var dy = (transform.localPosition.y - Position.y) / Position.y;
            var dz = (transform.localPosition.z - Position.z) / Position.z;

            var rx = (transform.localEulerAngles.x - Rotation.x) / Rotation.x;
            var ry = (transform.localEulerAngles.y - Rotation.y) / Rotation.y;
            var rz = (transform.localEulerAngles.z - Rotation.z) / Rotation.z;

            if (dx < 0.01 && dy < 0.01 && dz < 0.01 && rx < 0.01 && ry < 0.01 && rz < 0.01)
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
