using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMesh : MonoBehaviour
{

    private const int m_voxelCount = 32;
    // TODO: Check pixelation as voxel increases
    private const float m_increment = 1.0f/m_voxelCount;

    private List<Vector3> vertices = new List<Vector3>();
    // private Vector2[] uvs;
    private int[] triangles;

    void Start()
    {
        CreateCell(Vector3.zero);
        CreateCell(new Vector3(-1,-1,-1));
        CreateCell(new Vector3(-1,-1,0));
        CreateCell(new Vector3(0,-1,-1));
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
        // return -Mathf.Pow(pos.x - 0.5f, 2) - Mathf.Pow(pos.y - 0.5f, 2) - Mathf.Pow(pos.z -0.5f, 2) + 1/36f;
        return (Mathf.Sin(3*pos.x)) * Mathf.Sin(3*pos.z) - pos.y;
    }

    private void CreateCell(Vector3 pos)
    {
        // Create voxel in unit, assume (0,0,0) is bottom left corner of unit
        for (int x = 0; x < m_voxelCount; x++)
        {
            for (int y = 0; y < m_voxelCount; y++)
            {
                for (int z = 0; z < m_voxelCount; z++)
                {
                    Voxel v = new Voxel(new Vector3(x, y, z)*m_increment+pos, m_increment, DensityFunction);
                    Vector3[] t = v.GetTriangles();
                    foreach(Vector3 tri in t)
                    {
                        vertices.Add(tri);
                    }
                }            
            }
        }
    }
}