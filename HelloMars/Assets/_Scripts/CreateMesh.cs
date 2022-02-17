using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMesh : MonoBehaviour
{

    private const int m_voxelCount = 8;
    private const float m_increment = 1.0f/m_voxelCount;

    private Vector3[] vertices;
    // private Vector2[] uvs;
    private int[] triangles;

    void Start()
    {
        Voxel v = new Voxel(Vector3.zero, m_increment, DensityFunction);
        v.CalculateByte();
        vertices = v.GetTriangles();
        triangles = new int[vertices.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            triangles[i] = i;
        }

        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        // Assign vertices and triangles to mesh filter
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.Optimize();
        // Use Unity built-in normal calculations
        mesh.RecalculateNormals();

    }

    private double DensityFunction(Vector3 pos)
    {
        return (Mathf.Sin(pos.x)) * Mathf.Sin(pos.z) - pos.y - 0.01;
    }
}