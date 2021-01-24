using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DrawParentWaypointPath))]
public class WaypointParentHandles : Editor
{
    void OnSceneGUI()
    {
        DrawParentWaypointPath t = target as DrawParentWaypointPath;
        if (t == null)
            return;
        WaypointHandles.DrawPath(t.transform.parent.transform);
    }

}


