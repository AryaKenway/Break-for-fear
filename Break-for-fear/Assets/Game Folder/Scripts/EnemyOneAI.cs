using UnityEngine;
using UnityEngine.AI;

public class EnemyOneAI : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    public float updateRate = 0.25f; // Update path every 0.25 seconds

    private float timer;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = updateRate;

    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f && player != null)
        {
            agent.SetDestination(player.position);
            timer = updateRate;
        }
    }
}
