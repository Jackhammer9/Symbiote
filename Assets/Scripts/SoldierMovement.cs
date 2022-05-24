using UnityEngine;
using UnityEngine.AI;

public class SoldierMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 destination;

    public bool OverrideDestination = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = new Vector3(Random.Range(-190, 190), transform.position.y, Random.Range(-190, 190));
        agent.SetDestination(destination);
    }

    private void Update()
    {
        if(agent.remainingDistance < 10 && !OverrideDestination)
        {
            destination = new Vector3(Random.Range(-190, 190), transform.position.y, Random.Range(-190, 190));
            agent.SetDestination(destination);
        }
    }
}
