using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMesh : MonoBehaviour
{

    private const int m_voxelCount = 8;
    private const float m_increment = 1.0f/m_voxelCount;

    void Start()
    {
        Voxel v = new Voxel(Vector3.zero, m_increment);
        v.DensityFunc = DensityFunction;
        v.CalculateByte();
        Debug.Log(v.Case);
    }

    private double DensityFunction(Vector3 pos)
    {
        return (Mathf.Sin(pos.x)) * Mathf.Sin(pos.y) - pos.z;
    }
}