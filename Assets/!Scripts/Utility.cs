using System;
using UnityEngine;

[Serializable]
public struct RotationRestriction
{
    public Vector3 startingPosition;
    public Vector3 upperLimits;
    public Vector3 lowerLimits;

    public Vector3 RestrictValue(Vector3 toRestrict)
    {
        return new Vector3(
            Mathf.Clamp(toRestrict.x, lowerLimits.x + startingPosition.x, upperLimits.x + startingPosition.x),
            Mathf.Clamp(toRestrict.y, lowerLimits.y + startingPosition.y, upperLimits.y + startingPosition.y),
            Mathf.Clamp(toRestrict.z, lowerLimits.z + startingPosition.z, upperLimits.z + startingPosition.z));
    }

}
