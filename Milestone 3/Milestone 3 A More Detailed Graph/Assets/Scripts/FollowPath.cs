using UnityEngine;

public class FollowPath : MonoBehaviour
{
    Transform goal;

    [SerializeField] private float speed;
    [SerializeField] private float accuracy;
    [SerializeField] private float rotSpeed;

    

    private bool moveToLocation;

    public GameObject wpManager;
    GameObject[] wps;
    GameObject currentNode;

    int currentWaypointIndex = 0;
    Graph graph;

    // Start is called before the first frame update
    void Start()
    {
        wps = wpManager.GetComponent<WaypointManager>().waypoints;
        graph = wpManager.GetComponent<WaypointManager>().graph;
        currentNode = wps[0];
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (graph.getPathLength() == 0 || currentWaypointIndex == graph.getPathLength())
        {
            return;
        }

        currentNode = graph.getPathPoint(currentWaypointIndex);


        currentNode = graph.getPathPoint(currentWaypointIndex);

        if (Vector3.Distance(graph.getPathPoint(currentWaypointIndex).transform.position,
            transform.position) < accuracy)
        {
            currentWaypointIndex++;
        }

        if (currentWaypointIndex < graph.getPathLength())
        {
            goal = graph.getPathPoint(currentWaypointIndex).transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x, transform.position.y, goal.position.z);
            Vector3 direction = lookAtGoal - this.transform.position;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);
            this.transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }

    public void goToCommandCenter()
    {
        graph.AStar(currentNode, wps[0]);
        currentWaypointIndex = 0;
    }
    public void goToMountains()
    {
        graph.AStar(currentNode, wps[2]);
        currentWaypointIndex = 0;
    }

    public void goToMiddle()
    {
        graph.AStar(currentNode, wps[3]);
        currentWaypointIndex = 0;
    }

    public void goToOilRefinery()
    {
        graph.AStar(currentNode, wps[4]);
        currentWaypointIndex = 0;
    }

    public void goToTankers()
    {
        graph.AStar(currentNode, wps[7]);
        currentWaypointIndex = 0;
    }
    public void goToBarracks()
    {
        graph.AStar(currentNode, wps[8]);
        currentWaypointIndex = 0;
    }

    
    public void goToRadar()
    {
        graph.AStar(currentNode, wps[9]);
        currentWaypointIndex = 0;
    }

    public void goToCommandPost()
    {
        graph.AStar(currentNode, wps[10]);
        currentWaypointIndex = 0;
    }

    
}
