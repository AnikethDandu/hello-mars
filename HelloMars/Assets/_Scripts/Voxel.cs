using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voxel : MonoBehaviour
{
    // Class variables
    delegate void DensityFunction();
    private static DensityFunction m_func;
    static private double m_increment;
    private Vector3 m_botLeftCoord;
    private byte m_case;

    // Properties
    public Vector3 BotLeftCoord
    {
        get { return m_botLeftCoord; }
        set { m_botLeftCoord = value; }
    }

    public byte Case
    {
        get { return m_case; }
    }

    DensityFunction Func
    {
        get { return m_func; }
        set { m_func = value;}
    }

    // Constructor
    public Voxel(Vector3 pos, double increment)
    {
        BotLeftCoord = pos;
        m_increment = increment;
    }

    private void CalculateByte()
    {
        Vector3[] coords = new Vector3[8];
        coords[0] = BotLeftCoord;
    }
}
