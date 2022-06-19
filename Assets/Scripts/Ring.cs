using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    [SerializeField] private GameObject flame;

    public bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        // FlameOn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FlameOn()
    {
        flame.gameObject.SetActive(true);
        isActive = true;

        var source = GetComponent<AudioSource>();
        source.PlayOneShot(source.clip);
    }

    public void FlameOff()
    {
        flame.gameObject.SetActive(false);
        isActive = false;
    }
}
