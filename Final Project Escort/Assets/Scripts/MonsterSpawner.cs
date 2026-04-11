using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject secondObstacle;
    GameObject[] agents;

    private void Start()
    {
        agents = GameObject.FindGameObjectsWithTag("Agent");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                Instantiate(secondObstacle, hit.point, secondObstacle.transform.rotation);
                foreach (GameObject a in agents)
                {
                    a.GetComponent<AIControl1>().goToObstacle(hit.point);
                }
            }
        }
    }
}
