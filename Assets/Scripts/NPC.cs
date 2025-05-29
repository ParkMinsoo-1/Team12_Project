using UnityEngine;
using UnityEngine.AI;

enum AiState
{
    idle,
    wandering
}

public class NPC : MonoBehaviour
{
    [Header("Moving")]
    [SerializeField] float walkSpeed;

    [Header("AI")]
    private NavMeshAgent agent;
    public float detectDistance;
    private AiState aiState;

    [Header("Wandering")]
    public float minWanderDistance;
    public float maxWanderDistance;
    public float minWanderWaitTime;
    public float maxWanderWaitTime;
    Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        SetState(AiState.wandering);        
    }

    void Update()
    {
        animator.SetBool("isRun", aiState != AiState.idle);
        PassiveUpdate();
    }

    private void SetState(AiState state)
    {
        aiState = state;

        switch(aiState)
        {
            case AiState.idle:
                agent.speed = walkSpeed;
                agent.isStopped = true;
                
                break;
            case AiState.wandering:
                agent.speed = walkSpeed;
                agent.isStopped = false;
                
                break;
        }
    }

    void PassiveUpdate()
    {
        if(aiState == AiState.wandering && agent.remainingDistance < 0.1f)
        {
            SetState(AiState.idle);
            Invoke("WanderToNewLocation", Random.Range(minWanderWaitTime, maxWanderWaitTime));
        }
    }

    void WanderToNewLocation()
    {
        if (aiState != AiState.idle) return;
        
        SetState(AiState.wandering);
        agent.SetDestination(WanderDestination());
    }

    Vector3 WanderDestination()
    {
        NavMeshHit hit;
        NavMesh.SamplePosition(transform.position + (Random.onUnitSphere * Random.Range(minWanderDistance, maxWanderDistance)), out hit, maxWanderDistance, NavMesh.AllAreas);
        
        return hit.position;
    }
}
