using UnityEngine;

public static class ExtendingVector3
{
    public static bool IsGreaterOrEqual(Vector3 local, Vector3 other)
    {
        return local.x >= other.x ||  local.z >= other.z;
    }

    public static bool IsLesserOrEqual(Vector3 local, Vector3 other)
    {
        return local.x <= other.x || local.z <= other.z;
    }
}