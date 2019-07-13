using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class enemy : MonoBehaviour
{
    
    public GameObject target;
    NavMeshAgent nma;
    void Start()
    {
        nma = GetComponent<NavMeshAgent>();

    }
    void Update()
    {
        if (TimerClass.gamemode == "PLAY")
        {
            nma.SetDestination(target.transform.position);
            float distance = Vector3.Distance(transform.position, target.transform.position);
            // Debug.Log(distance);
            if (distance <= 2.7f)
            {
                GetComponent<Animator>().Play("stabbing");
            }
            else
                GetComponent<Animator>().Play("walking");
        }
    }
    
}
