using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VongolaBoxLid : MonoBehaviour
{
    private VongolaBox box;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ring>() != null)
        {
            if (!box.isActive && other.GetComponent<Ring>().isActive)
            {
                box.Activate();
            }
        }
    }
}
