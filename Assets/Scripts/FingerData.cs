using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/FingerData", order = 1)]
public class FingerData : ScriptableObject
{
    [SerializeField, Range(-1.0f, 1.0f)] private float thum = 0;
    [SerializeField, Range(-1.0f, 1.0f)] private float index = 0;
    [SerializeField, Range(-1.0f, 1.0f)] private float middle = 0;
    [SerializeField, Range(-1.0f, 1.0f)] private float ring = 0;
    [SerializeField, Range(-1.0f, 1.0f)] private float little = 0;

    [SerializeField, Range(-1.0f, 1.0f)] private float thumOpen = 0;
    [SerializeField, Range(-1.0f, 1.0f)] private float indexOpen = 0;
    [SerializeField, Range(-1.0f, 1.0f)] private float middleOpen = 0;
    [SerializeField, Range(-1.0f, 1.0f)] private float ringOpen = 0;
    [SerializeField, Range(-1.0f, 1.0f)] private float littleOpen = 0;

    public float[] toArray()
    {
        return new float[] { thum, index, middle, ring, little, thumOpen, indexOpen, middleOpen, ringOpen, littleOpen };
    }
}
