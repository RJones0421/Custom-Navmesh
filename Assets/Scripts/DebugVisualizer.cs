using UnityEngine;

public class DebugVisualizer : MonoBehaviour
{
  [SerializeField]
  private NavMeshBuilder m_Builder;

  [SerializeField]
  private bool m_DisplayBoundingBox = false;

  private void OnDrawGizmos()
  {
    // AABB of world colliders
    DrawWireBox(m_DisplayBoundingBox, m_Builder.GetBoundsMin(), m_Builder.GetBoundsMax(), Color.red);
  }

  private void DrawWireBox(bool shouldDisplay, Vector3 min, Vector3 max, Color color)
  {
    if (!shouldDisplay) return;
    
    // Build lines for box
    Vector3[] points = new Vector3[24]
    {
      // Bottom
      min,
      new Vector3(min.x, min.y, max.z),
      min,
      new Vector3(max.x, min.y, min.z),
      new Vector3(max.x, min.y, min.z),
      new Vector3(max.x, min.y, max.z),
      new Vector3(min.x, min.y, max.z),
      new Vector3(max.x, min.y, max.z),

      // Sides
      min,
      new Vector3(min.x, max.y, min.z),
      new Vector3(max.x, min.y, min.z),
      new Vector3(max.x, max.y, min.z),
      new Vector3(max.x, min.y, max.z),
      new Vector3(max.x, max.y, max.z),
      new Vector3(min.x, min.y, max.z),
      new Vector3(min.x, max.y, max.z),

      // Top
      max,
      new Vector3(max.x, max.y, min.z),
      max,
      new Vector3(min.x, max.y, max.z),
      new Vector3(min.x, max.y, min.z),
      new Vector3(max.x, max.y, min.z),
      new Vector3(min.x, max.y, max.z),
      new Vector3(min.x, max.y, min.z)
    };

    Gizmos.color = color;
    Gizmos.DrawLineList(points);
}
}
