using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMesh : MonoBehaviour
{

    private const int m_voxelCount = 8;
    private const float m_increment = 1.0f/m_voxelCount;

    private List<Vector3> vertices = new List<Vector3>();
    // private Vector2[] uvs;
    private int[] triangles;

    void Start()
    {
        for (int x = 0; x < m_voxelCount; x++)
        {
            for (int y = 0; y < m_voxelCount; y++)
            {
                for (int z = 0; z < m_voxelCount; z++)
                {
                    Voxel v = new Voxel(new Vector3(x, y, z) * (float)(m_increment), m_increment, DensityFunction);
                    v.CalculateByte();
                    Vector3[] t = v.GetTriangles();
                    foreach(Vector3 tri in t)
                    {
                        vertices.Add(tri);
                    }
                }            
            }
        }
        triangles = new int[vertices.Count];
        for (int i = 0; i < vertices.Count; i++)
        {
            triangles[i] = i;
        }

        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        // Assign vertices and triangles to mesh filter
        mesh.Clear();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles;
        mesh.Optimize();
        // Use Unity built-in normal calculations
        mesh.RecalculateNormals();

    }

    private double DensityFunction(Vector3 pos)
    {
        return -Mathf.Pow(pos.x - 1/2, 2) - Mathf.Pow(pos.y - 1/2, 2) - Mathf.Pow(pos.z - 1/2, 2) + 1.0/9.0;
        // return (Mathf.Sin(pos.x)) * Mathf.Sin(pos.z) - pos.y - 0.01;
    }
}