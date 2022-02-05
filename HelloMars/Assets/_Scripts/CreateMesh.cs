using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMesh : MonoBehaviour
{

    private const int m_voxelCount = 8;
    private const double m_increment = 1.0/m_voxelCount;

    void Start()
    {
        Voxel v = new Voxel(Vector3.zero, m_increment);
    }
}