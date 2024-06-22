using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]

public class TraceEnemy : MonoBehaviour
{
    //[SerializeField] private PlayerController _playerController;
    private NavMeshAgent _agent;
    private RaycastHit[] _raycastHits = new RaycastHit[10];
    //private Vector3 position_now;
    private Vector3 position_pre;

    private Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        position_pre = transform.position;
    }

    
    //Update is called once per frame
    /*
    private void Update()
    {
        //_agent.destination = _playerController.transform.position;
        //_agent.destination = default.transform.position;
        var position_now = transform.position;
        Debug.Log(position_now-position_pre);
        if(position_pre == position_now)
        {
            anim.SetBool("Running", false);
            Debug.Log("Idle");
        }
        else
        {
            anim.SetBool("Running", true);
            Debug.Log("Run");
        }
        position_pre = position_now;
    }
    */
    

    public void OnDetectObject(Collider collider)
    {

        if(collider.CompareTag("Player"))
        {
            var positonDiff = collider.transform.position - transform.position;
            var distance = positonDiff.magnitude;
            var direction = positonDiff.normalized;

            var hitCount = Physics.RaycastNonAlloc(transform.position, direction, _raycastHits, distance);
            //Debug.Log("hitCount: " + hitCount);
            if(hitCount == 1)
            {
                _agent.isStopped = false;
                _agent.destination = collider.transform.position;
                anim.SetBool("Running", true);
                //Debug.Log("Run");
            }
            else
            {
                _agent.isStopped = true;
                anim.SetBool("Running", false);
                //Debug.Log("Idle");
            }
        }
    }
}
