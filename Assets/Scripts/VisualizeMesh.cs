using UnityEngine;

public class VisualizeMesh : MonoBehaviour
{
  [SerializeField] MeshFilter m_MeshFilter;
  Mesh m_Mesh;

  private void Awake()
  {
    m_Mesh = new Mesh();
    m_MeshFilter.mesh = m_Mesh;
    GenerateNavMesh();
  }

  private void GenerateNavMesh()
  {
    // Vertex and index arrays
    Vector3[] verticies = new Vector3[7];
    int[] triangles = new int[9];

    // Points used for testing
    verticies[0] = new Vector3(1, 0, 0);
    verticies[1] = new Vector3(-1, 0, 0);
    verticies[2] = new Vector3(0, 1, 0);
    verticies[3] = new Vector3(2, 1, 0);
    verticies[4] = new Vector3(1, 2, 0);
    verticies[5] = new Vector3(-1, 2, 0);
    verticies[6] = new Vector3(0, 3, 0);

    // Left triangle
    triangles[0] = 0;
    triangles[1] = 1;
    triangles[2] = 2;
    // Right triangle
    triangles[3] = 0;
    triangles[4] = 2;
    triangles[5] = 3;
    // Floating triangle
    triangles[6] = 4;
    triangles[7] = 5;
    triangles[8] = 6;

    // Assign
    m_Mesh.vertices = verticies;
    m_Mesh.triangles = triangles;
  }
}
