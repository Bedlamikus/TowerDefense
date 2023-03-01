using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject : MonoBehaviour
{
    protected ActiveUnitController m_activeUnit;
    private Camera m_camera;

    protected virtual void Start()
    {
        m_activeUnit = FindObjectOfType<ActiveUnitController>();
        m_camera = Camera.main;
    }

    protected virtual void OnMouseDown()
    {
        return;
    }

    public Vector3 GetVectorClick()
    {
        RaycastHit hit;
        if (Physics.Raycast(m_camera.ScreenPointToRay(Input.mousePosition), out hit))
        {
            return hit.point;
        }
        return Vector3.zero;
    }
}
