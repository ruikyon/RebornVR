using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private HoldableObject holdable;

    // Start is called before the first frame update
    void Start()
    {
        holdable = GetComponent<HoldableObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!holdable.IsHolding && transform.position.y < 0.6f)
        {
            var rig = GetComponent<Rigidbody>();
            rig.velocity = Vector3.zero;
            rig.useGravity = false;

            transform.position = new Vector3(transform.position.x, 0.606f, transform.position.z);
            transform.eulerAngles = new Vector3(-11.189f, transform.eulerAngles.y, 0);
        }
    }
}
