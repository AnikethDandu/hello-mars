using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Voxel
{
    // Class variables
    public delegate double DensityFunction(Vector3 pos);
    private static DensityFunction m_func;
    static private float m_increment;
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
        set { m_case = value; }
    }

    public DensityFunction DensityFunc
    {
        get { return m_func; }
        set { m_func = value;}
    }

    // Constructor
    public Voxel(Vector3 pos, float increment)
    {
        BotLeftCoord = pos;
        m_increment = increment;
        Case = 0;
    }

    public void CalculateByte()
    {
        Vector3[] coords = new Vector3[8];
        coords[0] = BotLeftCoord;
        coords[1] = coords[0] + m_increment * Vector3.up;
        coords[2] = coords[1] + m_increment * Vector3.right;
        coords[3] = coords[2] + m_increment * Vector3.down;
        coords[4] = coords[0] + m_increment * Vector3.forward;
        coords[5] = coords[1] + m_increment * Vector3.forward;
        coords[6] = coords[2] + m_increment * Vector3.forward;
        coords[7] = coords[3] + m_increment * Vector3.forward;

        for (int i = 0; i < 8; i++) 
        {
            // ret &= (byte)(Convert.ToInt32((m_func(coords[i]) > 0)) << i)
            // ret |= (m_func(coords[i]) > 0) ? (byte)(1 << i) : (byte)0;
            if (DensityFunc(coords[i]) > 0)
            {
                Case |= (byte)(1 << i);
            }
        }
    }
}
