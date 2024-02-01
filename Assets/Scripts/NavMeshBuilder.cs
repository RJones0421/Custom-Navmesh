using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMeshBuilder : MonoBehaviour
{
  [SerializeField]
  private Collider[] m_WalkableObjects;

  private Vector3 m_BoundsMin;
  private Vector3 m_BoundsMax;

  // Currently will gather anything with a physics collider in the scene.
  // Future improvements could be to add filters or flag items that are supposed to be walkable
  public void GetPhysicsColliders()
  {
    Debug.Log("Gathered");
    m_WalkableObjects = GameObject.FindObjectsOfType<Collider>();
  }

  public void GenerateNavMesh()
  {
    // Find the bounds the navmesh will be contained within
    CalculateAABB();
  }

  private void CalculateAABB()
  {
    foreach (Collider c in m_WalkableObjects)
    {
      // Set min
      m_BoundsMin.x = Mathf.Min(m_BoundsMin.x, c.bounds.min.x);
      m_BoundsMin.y = Mathf.Min(m_BoundsMin.y, c.bounds.min.y);
      m_BoundsMin.z = Mathf.Min(m_BoundsMin.z, c.bounds.min.z);

      // Set max
      m_BoundsMax.x = Mathf.Max(m_BoundsMax.x, c.bounds.max.x);
      m_BoundsMax.y = Mathf.Max(m_BoundsMax.y, c.bounds.max.y);
      m_BoundsMax.z = Mathf.Max(m_BoundsMax.z, c.bounds.max.z);
    }
  }

  // ======================================================================
  // Accessors

  public Vector3 GetBoundsMin()
  {
    return m_BoundsMin;
  }

  public Vector3 GetBoundsMax()
  {
    return m_BoundsMax;
  }
}
