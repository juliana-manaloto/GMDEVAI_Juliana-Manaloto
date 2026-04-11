using UnityEngine;
using UnityEngine.UI;

public class FollowPath : MonoBehaviour
{
    Transform goal;
    public Button first;
    public Button second;
    public Button third;
    [SerializeField]  public float speed;
    [SerializeField] private float accuracy;
    [SerializeField] private float rotSpeed;
    public float time = 30;
    

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
    public void FirstStop()
    {
        graph.AStar(currentNode, wps[4]);
        currentWaypointIndex = 0;
        first.gameObject.SetActive(false);

        second.gameObject.SetActive(true);
        

    }
    public void SecondStop()
    {
        graph.AStar(currentNode, wps[6]);
        currentWaypointIndex = 0;
        second.gameObject.SetActive(false);
        
        
            third.gameObject.SetActive(true);
           

        
    }
    public void goClientDestination()
    {
        graph.AStar(currentNode, wps[8]);
        third.gameObject.SetActive(false);
        currentWaypointIndex = 0;
    }
    
    
}
