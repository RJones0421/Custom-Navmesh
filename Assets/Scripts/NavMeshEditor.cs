using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(NavMeshBuilder))]
public class NavMeshEditor : Editor
{
  public override void OnInspectorGUI()
  {
    NavMeshBuilder builder = (NavMeshBuilder)target;
    if (GUILayout.Button("Get Physics Colliders"))
    {
      builder.GetPhysicsColliders();
    }

    if (GUILayout.Button("Generate NavMesh (WIP)"))
    {
      builder.GenerateNavMesh();
    }

    DrawDefaultInspector();
  }
}
