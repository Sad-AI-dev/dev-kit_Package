using UnityEngine;
using UnityEditor;
using DevKit;

[CustomEditor(typeof(ObjectSpawner))]
public class ObjectSpawnerEditor : Editor
{
    ObjectSpawner spawner;

    private void Awake()
    {
        if (spawner == null) {
            spawner = target as ObjectSpawner;
        }
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Refresh spawn points")) {
            spawner.CompileSpawnPoints();
        }
    }
}
