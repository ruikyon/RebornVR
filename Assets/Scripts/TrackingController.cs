using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingController : MonoBehaviour
{
    [SerializeField] private Transform player, hmd, lController, rController;

    // 以下はどちらかというとモデルの情報なのでここに書くことなのかという気はする(引数に取る？)
    [SerializeField] private float headOffset = 1.35f;
    [SerializeField] private float lengthHandToHand = 1.14f;

    private Vector3 prePosision;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // CameraRigをplayerに追従させる
        transform.position = player.position - prePosision;
        prePosision = player.position;
    }

    public void ResetHeight()
    {
        var temp = player.position.y + headOffset - hmd.position.y;
        transform.position += Vector3.up * temp;
    }

    public void ResetWidth()
    {
        var length = 0f;
        var newlength = Vector3.Distance(lController.position, rController.position);
        if (newlength > 0)
        {
            length = newlength;
        }

        transform.localScale *= lengthHandToHand / length;
    }

    public void ResetRot()
    {
        var forward = hmd.forward;
        forward.y = 0;
        player.forward = forward;

        // var boxDir = sensorRot * Vector3.forward;
        // boxDir.y = 0;
        // playerRot.SetFromToRotation(boxDir, hmd.forward);
    }

    public void ResetAll()
    {
        ResetHeight();
        ResetWidth();
        ResetRot();
    }
}