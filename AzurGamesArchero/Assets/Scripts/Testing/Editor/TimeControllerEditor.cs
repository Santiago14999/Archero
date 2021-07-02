using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TimeController))]
public class TimeControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var timeController = (TimeController)target;
        if (GUILayout.Button("Update Time Scale"))
            timeController.UpdateTimeScale();
    }
}
