using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private HumanPose _targetHumanPose;

    private int[] lFingerIndexes = new int[] {
        // 55,
        57,58,59,61,62,63,65,66,67,69,70,71,73,74
    };

    private int[] rFingerIndexes = new int[] {
        // 75,
        77,78,79,81,82,83,85,86,87,89,90,91,93,94
    };

    private float curL = 0, curR = 0;

    public bool grabL = false, grabR = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        var targetL = grabL ? -1 : 0.4f;
        var targetR = grabR ? -1 : 0.4f;
        // {
        // Animator avater → handler → HumanPose と渡す
        // HumanPose の値を変更して、handlerへ渡すとHumanBoneに変更が適用される。
        var handler = new HumanPoseHandler(animator.avatar, animator.transform);
        handler.GetHumanPose(ref _targetHumanPose);

        //HumanPoseを更新
        int muscles = _targetHumanPose.muscles.Length;


        foreach (var index in lFingerIndexes)
        {
            float move = Time.deltaTime * (targetL - curL); //moveの係数だけ変化します
            _targetHumanPose.muscles[index] = curL + move;
            curL = curL + move;
        }

        foreach (var index in rFingerIndexes)
        {
            float move = Time.deltaTime * (targetR - curR); //moveの係数だけ変化します
            _targetHumanPose.muscles[index] = curR + move;
            curR = curR + move;
        }

        //変更を適用する場合… SetHumanPose で変更した HumanPose を渡す
        handler.SetHumanPose(ref _targetHumanPose);
    }
}
