using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCube : MonoBehaviour
{

    private Vector3[] vertices = new Vector3[8];
    private Vector2[] uvs;
    private int[] triangles = new int[6];

    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        for (int i = 0; i < 8; i++) {
            vertices[i] = new Vector3(i >> 2, i >> 1 & 1, i & 1);
        }

        triangles = new int[]
        {
            0,2,1,
            2,3,1
        };

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
