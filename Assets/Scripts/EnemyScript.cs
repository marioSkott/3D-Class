using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] NavMeshAgent meshAgent;
    [SerializeField] Transform wayPoint;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float alertRadius;
    [SerializeField] Transform[]  wayPoints;
    [SerializeField] Vector3 currentTarget;

    [SerializeField] bool inRange=false;
    bool callReset=true;
    void Start()
    {
        if (meshAgent == null)
        {
            meshAgent = GetComponent<NavMeshAgent>();
        }
        currentTarget = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        inRange = Physics.CheckSphere(gameObject.transform.position,alertRadius, layerMask);

        if(inRange)
        {
            currentTarget = wayPoint.position;
            callReset= true;
            
        }
        else
        {
            currentTarget = Loiter();
        }

        meshAgent.destination= currentTarget;   
    }

    private void OnDrawGizmos()
    {
       //Gizmos.DrawSphere(transform.position, alertRadius);
    }

    Vector3 Loiter()
    {
        if(callReset)
        {
            callReset = false;
            
            return GetRandomPos().position;            
        }
        else
        {
            Vector2 selfPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.z);
            Vector2 tarPos = new Vector2(currentTarget.x, currentTarget.z);


            if(Vector2.Distance(selfPos,tarPos) < 3f)
            {
                Debug.Log("switch");
                return GetRandomPos().position;
            }else
            {
                return currentTarget;
            }
        }
    }

    Transform GetRandomPos()
    {
        int index = Random.Range(0, wayPoints.Length);

        return wayPoints[index];
    }

}