using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPVMotorRotationMono : MonoBehaviour
{

    public float m_speedPercent = 0.5f;
    public float m_speedRotationMin = 600f;
    public float m_speedRotationMax = 3600f;
    public Transform m_whatToRotate;
    public Vector3 m_axisRotation= Vector3.up;
    public bool m_inverse;
    private void Reset()
    {
        m_whatToRotate = transform;
    }
    public void SetSpeedPercent(float speedPercent)
    {
        m_speedPercent = speedPercent;
    }
    public void Update()
    {
        float speed = 0;
        if (m_speedPercent > 0)
        {
            speed = Mathf.Lerp(m_speedRotationMin, m_speedRotationMax, m_speedPercent);
        }
        if(m_speedPercent < 0)
        {
            speed = Mathf.Lerp(m_speedRotationMin, m_speedRotationMax, -m_speedPercent);
        }
        m_whatToRotate.Rotate(m_axisRotation,(m_inverse?-1:1)* speed  * Time.deltaTime);
    }


}
