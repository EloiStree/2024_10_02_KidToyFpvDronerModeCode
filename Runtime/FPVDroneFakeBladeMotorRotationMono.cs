using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPVDroneFakeBladeMotorRotationMono : MonoBehaviour
{
    public FPVDroneBasicMoveMono m_sourceToObserve;
    public FPVMotorRotationMono m_frontLeft;
    public FPVMotorRotationMono m_frontRight;
    public FPVMotorRotationMono m_backLeft;
    public FPVMotorRotationMono m_backRight;

    public bool m_keepMotorRunning = true;
    public float m_percentDeathZone = 0.05f;
    void Update()
    {

        float speed = 0;
        if (m_keepMotorRunning) { 
        
            speed = 0.01f;
        }
        FPVDroneBasicMoveMono s = m_sourceToObserve;

        IfOneIsNotZero(s, out bool oneIsNotZero);
        if(oneIsNotZero)
        {
            speed = 0.1f * Mathf.Sign(s.m_throttleFrontPercent);
            speed += s.m_throttleFrontPercent;
            m_frontLeft.SetSpeedPercent(speed);
            m_frontRight.SetSpeedPercent(speed);
            m_backLeft.SetSpeedPercent(speed);
            m_backRight.SetSpeedPercent(speed);
        }
        
    }

    private void IfOneIsNotZero(FPVDroneBasicMoveMono s, out bool oneIsNotZero)
    {
        float f = Math.Abs(s.m_throttleFrontPercent);
        float b = Math.Abs(s.m_rotateLeftRightPercent);
        float l = Math.Abs(s.m_rollLeftRightPercent);
        float r = Math.Abs(s.m_pitchBackForwardPercent);
        oneIsNotZero = f > m_percentDeathZone || b > m_percentDeathZone || l > m_percentDeathZone || r > m_percentDeathZone;
    }
}
