using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHoldable
{
    public Vector3 holdingPosition { get; }
    public Vector3 holdingRotation { get; }
}

[Serializable]
public class HoldingData
{

}