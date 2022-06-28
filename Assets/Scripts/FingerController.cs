using UnityEngine;

public class FingerController : MonoBehaviour
{
    public FingerData lFingerData, rFingerData;
    private float[] lCurrent = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    private float[] rCurrent = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    [SerializeField] private Holder lHolder, rHolder;

    [SerializeField] private Animator animator;

    private readonly int[][] lFingerIndexes = new int[][] {
        new int[] {57,58},
        new int[] {59,61,62},
        new int[] {63,65,66},
        new int[] {67,69,70},
        new int[] {71,73,74},
        new int[] {56},
        new int[] {60},
        new int[] {64},
        new int[] {68},
        new int[] {72},
    };

    private readonly int[][] rFingerIndexes = new int[][] {
        new int[] {77,78},
        new int[] {79,81,82},
        new int[] {83,85,86},
        new int[] {87,89,90},
        new int[] {91,93,94},
        new int[] {76},
        new int[] {80},
        new int[] {84},
        new int[] {88},
        new int[] {92},
    };

    private void LateUpdate()
    {
        var handler = new HumanPoseHandler(animator.avatar, animator.transform);
        HumanPose targetHumanPose = new HumanPose();
        handler.GetHumanPose(ref targetHumanPose);

        var lTargets = lFingerData.toArray();
        if (lHolder.fingerData != null)
        {
            lTargets = lHolder.fingerData.toArray();
        }
        for (var i = 0; i < 10; i++)
        {
            lCurrent[i] += 10 * Time.deltaTime * (lTargets[i] - lCurrent[i]);

            for (var j = 0; j < lFingerIndexes[i].Length; j++)
            {
                targetHumanPose.muscles[lFingerIndexes[i][j]] = lCurrent[i];
            }
        }

        var rTargets = rFingerData.toArray();
        if (rHolder.fingerData != null)
        {
            rTargets = rHolder.fingerData.toArray();
        }
        for (var i = 0; i < 10; i++)
        {
            rCurrent[i] += 10 * Time.deltaTime * (rTargets[i] - rCurrent[i]);

            for (var j = 0; j < rFingerIndexes[i].Length; j++)
            {
                targetHumanPose.muscles[rFingerIndexes[i][j]] = rCurrent[i];
            }
        }

        handler.SetHumanPose(ref targetHumanPose);
    }
}
