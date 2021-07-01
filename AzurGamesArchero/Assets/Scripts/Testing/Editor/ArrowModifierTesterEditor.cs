using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ArrowModifierTester))]
public class ArrowModifierTesterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var tester = (ArrowModifierTester)target;
        if (GUILayout.Button("Add Modifier"))
            tester.AddModifier();
    }
}
