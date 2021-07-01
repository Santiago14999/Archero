using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemiesSpawner))]
public class EnemiesSpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var spawner = (EnemiesSpawner)target;
        if (GUILayout.Button("Spawn Enemy"))
            spawner.SpawnEnemy();
    }
}
