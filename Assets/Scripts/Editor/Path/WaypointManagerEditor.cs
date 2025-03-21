using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
[CustomEditor(typeof(WaypointPath))]
public class WaypointManagerEditor : Editor
{
    private WaypointPath _path;

    private void OnEnable()
    {
        _path = (WaypointPath)target;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Add Point"))
        {
            _path.AddPoint();
        }

        if (GUILayout.Button("Clear Points"))
        {
            _path.ClearPoints();
        }
    }
}
#endif