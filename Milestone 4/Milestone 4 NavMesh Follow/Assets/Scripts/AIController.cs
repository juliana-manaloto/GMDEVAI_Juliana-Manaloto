using UnityEngine;

public class AIController : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;

    private void Start()
    {
        this.agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
}
