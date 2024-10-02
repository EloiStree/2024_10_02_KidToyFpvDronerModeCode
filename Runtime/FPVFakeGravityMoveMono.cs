using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPVFakeGravityMoveMono : MonoBehaviour
{
    public Transform m_whatToMove;
    public float m_speedDownPerSeconds = 1;
    public bool m_useGravity = true;

    public LayerMask m_layerRaycast;
    public float m_radiusOfRaycast = 0.05f;

 
    public void SetUseGravity(bool useGravity)
    {
        m_useGravity = useGravity;
    }


    void LateUpdate()
    {
        if (m_useGravity) {

            if (Physics.SphereCast(m_whatToMove.position+ Vector3.down*m_radiusOfRaycast,
                m_radiusOfRaycast
                , Vector3.down,
                out RaycastHit hit,
                float.MaxValue,
                m_layerRaycast)){ 
            
                m_whatToMove.Translate(Vector3.down * m_speedDownPerSeconds * Time.deltaTime, Space.World);   
            }
        }
    }
    private void Reset()
    {
        m_whatToMove = transform;
    }
}
