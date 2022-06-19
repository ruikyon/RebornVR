using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class VongolaBox : MonoBehaviour
{
    [SerializeField] private Transform lidL, lidR;
    public bool targetState = false;
    public bool currentState = false;
    public bool isRunning { get { return targetState != currentState; } }

    public bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        Activate();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            var curRot = lidL.localEulerAngles.x;
            Debug.Log("cur: " + curRot);

            var targetRot = targetState ? 90 : 0;
            // TODO: quarternionにした方が良いかも(このままだと90度以上にするのがめんどくさそう)
            Debug.Log("target: " + targetRot);

            var diffRot = targetRot - curRot;
            Debug.Log("diff: " + diffRot);

            var newRot = curRot + diffRot * 0.1f;
            Debug.Log("new: " + newRot);

            if (Mathf.Abs(diffRot) < 1)
            {
                currentState = targetState;
            }
            else
            {
                lidL.localEulerAngles = new Vector3(newRot, 0, 0);
                lidR.localEulerAngles = new Vector3(-newRot, 0, 0);
            }
        }
    }

    public void Activate()
    {
        isActive = true;
        OpenBox();
    }

    private async void OpenBox()
    {
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
        Debug.Log(other.name);
        if (other.GetComponent<Ring>() != null)
        {
            if (!isActive && other.GetComponent<Ring>().isActive)
            {
                Activate();
            }
        }
    }
}
