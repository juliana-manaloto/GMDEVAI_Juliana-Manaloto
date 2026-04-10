using UnityEngine;

public class AgentManager : MonoBehaviour
{
   public GameObject[] agents;
   public GameObject Player;
    float rotspeed = 10;
    void Start()
    {
        agents = GameObject.FindGameObjectsWithTag("AI");
    }

    // Update is called once per frame
    void Update()
    {
       
        
            foreach (GameObject ai in agents)
        
            ai.GetComponent<AIController>().agent.SetDestination(Player.transform.position);
        
    }
}
