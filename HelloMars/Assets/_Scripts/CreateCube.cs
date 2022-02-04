using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCube : MonoBehaviour
{
    private Vector3[] vertices = new Vector3[8];
    private Vector2[] uvs;
    private int[] triangles = new int[36];

    // Start is called before the first frame update
    void Start()
    {
        LabelVertices();
        CreateTriangles();
        CreateMesh();
    }

    private void LabelVertices() {
        // Label a cube vertex coordinate system from 0 - 7 (x,y,z)
        for (int i = 0; i < 8; i++) 
        {
            for (int j = 2; j >= 0; j--) {
                vertices[i][2-j] = (i >> j) & 1;
            }
        }
    }

    private void CreateTriangles() {
        // Create groups of 3 vertices per triangle, splitting each face of a cube into 2 triangles
        triangles = new int[]
        {
            0,1,3,
            0,3,2,
            3,6,2,
            3,7,6,
            1,7,3,
            1,5,7,
            0,6,4,
            0,2,6,
            7,4,6,
            7,5,4,
            0,4,5,
            0,5,1
        };
    }

    private void CreateMesh() {
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
}
