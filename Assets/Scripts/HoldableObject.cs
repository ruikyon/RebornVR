using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldableObject : MonoBehaviour
{
    private bool isRight = true;

    // 右手に持つ時のパラメータ
    [SerializeField] private Vector3 position;
    [SerializeField] private Vector3 rotation;
    [SerializeField] private FingerData fingerData;

    [SerializeField] private Collider targetCollider;

    public bool IsHolding { get { return state != HoldState.Free; } }

    private Vector3 Position
    {
        get
        {
            if (!isRight)
            {
                return new Vector3(-position.x, position.y, position.z);
            }

            return position;
        }
    }

    public Vector3 Rotation
    {
        get
        {
            if (!isRight)
            {
                // zの値を180を基準に対称にする
                return new Vector3(rotation.x, -rotation.y, -rotation.z + 360);
            }

            return rotation;
        }
    }

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
            transform.localPosition = Vector3.Lerp(transform.localPosition, Position, Time.deltaTime * 5);
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

        isRight = holder.isRight;
    }

    public void EndHold()
    {
        state = HoldState.Free;
        transform.parent = null;

        GetComponent<Rigidbody>().useGravity = true;

        targetCollider.enabled = true;
    }
}
