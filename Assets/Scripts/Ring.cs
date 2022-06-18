using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    [SerializeField] private GameObject flame;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FlameOn()
    {
        flame.gameObject.SetActive(true);
    }

    public void FlameOff()
    {
        flame.gameObject.SetActive(false);
    }
}
