using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoboController : MonoBehaviour
{
    public Transform _destination;

    NavMeshAgent _roboAgent;

	// Use this for initialization
	void Start ()
    {
        _roboAgent = GetComponent<NavMeshAgent>();
        if (_roboAgent != null)
        {
            SetRoute();
        }
	}
	
	public void SetRoute()
    {
        if (_destination != null)
        {
            _roboAgent.SetDestination(_destination.transform.position);
        }
    }
}
