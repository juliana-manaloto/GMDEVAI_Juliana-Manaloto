using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl1 : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject target;
    Vector3 wanderTarget;
    float detectionRadius = 20;
    float flockRadius = 10;

    private void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
       
    }

    public void Update()
    {
        if (!canSeeTarget())
        {
            Wander();
            
        } else if (canSeeTarget())
        {
            Pursue();
            
        }
        
    }

    public void Seek(Vector3 location)
    {
        agent.SetDestination(location);
    }

    public void Pursue()
    {
        Vector3 targetDirection = target.transform.position - this.transform.position;

        float lookAhead = targetDirection.magnitude / (agent.speed + target.GetComponent<FollowPath>().speed);

        Seek(target.transform.position + target.transform.forward * lookAhead);
    }
   

    public void goToObstacle(Vector3 location)
    {
        if (Vector3.Distance(location, this.transform.position) < detectionRadius)
        {
            target= null;
            Vector3 flockDirection = (location - this.transform.position).normalized;
            Vector3 newGoal = this.transform.position + flockDirection * flockRadius;

            NavMeshPath path = new NavMeshPath();
            agent.CalculatePath(newGoal, path);

            if (path.status != NavMeshPathStatus.PathInvalid)
            {
                agent.SetDestination(path.corners[path.corners.Length - 1]);

                agent.speed = 10;
                agent.angularSpeed = 500;
            }
        }
    }

    public void Wander()
    {
        float wanderRadius = 30;
        float wanderDistance = 20;
        float wanderJitter = 1;

        wanderTarget += new Vector3(Random.Range(-1.0f, 1.0f) * wanderJitter, 0, Random.Range(-1.0f, 1.0f) * wanderJitter);
        wanderTarget.Normalize();
        wanderTarget *= wanderRadius;

        Vector3 targerLocal = wanderTarget + new Vector3(0, 0, wanderDistance);
        Vector3 targetWorld = this.gameObject.transform.InverseTransformDirection(targerLocal);

        Seek(targetWorld);
    }

    

    bool canSeeTarget()
    {
        RaycastHit raycastInfo;
        Vector3 rayToTarget = target.transform.position - this.transform.position;

        if (Physics.Raycast(this.transform.position, rayToTarget, out raycastInfo))
        {
            return raycastInfo.transform.gameObject.tag == "Player";
        }

        return false;
        
    }

    
}
