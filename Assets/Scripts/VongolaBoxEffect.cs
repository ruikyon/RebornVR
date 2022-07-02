using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VongolaBoxEffect : MonoBehaviour
{
    public float iniVelocity;

    public GameObject targetObject;
    public float yOffset;

    // Start is called before the first frame update
    void Start()
    {
        // test
        // GetComponent<Rigidbody>().AddForce(transform.forward * iniVelocity);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "ground") return;

        gameObject.SetActive(false);
        var tmp = Instantiate(targetObject);
        tmp.transform.position = new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z);
    }
}
