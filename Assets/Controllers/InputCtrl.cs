using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InputCtrl : MonoBehaviour
{
    private Camera m_camera;
    private NavMeshAgent agent;

    private void Start()
    {
        m_camera = Camera.main;
        agent = FindObjectOfType<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(m_camera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}
