using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]

public class TraceEnemy : MonoBehaviour
{
    private NavMeshAgent _agent;
    private RaycastHit[] _raycastHits = new RaycastHit[10];

    private Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    //Update is called once per frame
    private void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f)) 
        {
		return;
	    }
    }
    
    public void OnDetectObject(Collider collider)
    {

        if(collider.CompareTag("Player"))
        {
            var positonDiff = collider.transform.position - transform.position;
            var distance = positonDiff.magnitude;
            var direction = positonDiff.normalized;

            var hitCount = Physics.RaycastNonAlloc(transform.position, direction, _raycastHits, distance);
            //Debug.Log("hitCount: " + hitCount);
            if(hitCount == 2)
            {
                _agent.isStopped = false;
                _agent.destination = collider.transform.position;
            }
            else
            {
                _agent.isStopped = true;
            }
        }
    }
}
