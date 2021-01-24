using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DrawWaypointPath))]
public class WaypointHandles : Editor
{
    void OnSceneGUI()
    {
        DrawWaypointPath t = target as DrawWaypointPath;
        if (t == null)
            return;
        DrawPath(t.transform);
    }

    public static void DrawPath(Transform t)
    {
        if (t.childCount > 1)
        {
            Vector3 start;
            Vector3 finish;

            for (int i = 1; i < t.childCount; i++)
            {
                start = t.GetChild(i - 1).position;
                finish = t.GetChild(i).position;

                Handles.color = Color.green;
                Handles.DrawLine(start, finish);
            }

            start = t.GetChild(0).position;
            finish = t.GetChild(t.childCount - 1).position;
            Handles.color = Color.yellow;
            Handles.DrawLine(start, finish);
        }
    }
}


