using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class VongolaBox : MonoBehaviour
{
    [SerializeField] private Transform lidL, lidR;
    [SerializeField] private VongolaBoxEffect effect;
    [SerializeField] private GameObject entityItem;

    private bool targetState = false;
    private bool currentState = false;

    public bool isRunning { get { return targetState != currentState; } }
    public bool isActive = false;

    // Update is called once per frame
    void Update()
    {
        // test
        // if (Input.GetKeyDown(KeyCode.O))
        // {
        //     Activate();
        // }

        if (!isRunning) return;

        var curRot = lidL.localEulerAngles.x;

        var targetRot = targetState ? 90 : 0;
        // TODO: quarternionにした方が良いかも(このままだと90度以上にするのがめんどくさそう)

        var diffRot = targetRot - curRot;

        var newRot = curRot + diffRot * 0.1f;

        if (Mathf.Abs(diffRot) < 1)
        {
            currentState = targetState;
            return;
        }

        lidL.localEulerAngles = new Vector3(newRot, 0, 0);
        lidR.localEulerAngles = new Vector3(-newRot, 0, 0);
    }

    public async void Activate()
    {
        isActive = true;
        var source = GetComponent<AudioSource>();
        source.PlayOneShot(source.clip);

        await Task.Delay(1000);

        targetState = true;

        await Task.Delay(1000);

        var tmp = Instantiate(effect, transform.position, transform.rotation);
        tmp.GetComponent<Rigidbody>().AddForce(transform.up * 80);
        tmp.GetComponent<VongolaBoxEffect>().targetObject = entityItem;
        tmp.GetComponent<VongolaBoxEffect>().yOffset = 0.5f;

        await Task.Delay(5000);
        targetState = false;
        isActive = false;
    }
}
