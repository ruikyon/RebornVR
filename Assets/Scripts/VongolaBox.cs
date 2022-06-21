using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class VongolaBox : MonoBehaviour
{
    [SerializeField] private Transform lidL, lidR;

    private bool targetState = false;
    private bool currentState = false;

    public bool isRunning { get { return targetState != currentState; } }
    public bool isActive = false;

    // Update is called once per frame
    void Update()
    {
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

    private async void Activate()
    {
        isActive = true;

        await Task.Delay(1000);

        targetState = true;
        var source = GetComponent<AudioSource>();
        source.PlayOneShot(source.clip);

        await Task.Delay(5000);

        targetState = false;
        isActive = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ring>() != null)
        {
            if (!isActive && other.GetComponent<Ring>().isActive)
            {
                Activate();
            }
        }
    }
}
