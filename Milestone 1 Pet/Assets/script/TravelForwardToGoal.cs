using UnityEngine;

public class TravelForwardToGoal : MonoBehaviour
{
   public Transform goal;
    float speed = 5;
    float rotspeed = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 lookAtGoal = new Vector3(goal.position.x, this.transform.position.y, goal.position.z);
        // This makes the object go to the goal while its y axis position stays the same
        Vector3 direction = lookAtGoal - this.transform.position;
        // this is so the object faces the same direction of the goal
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, 
            Quaternion.LookRotation(direction), Time.deltaTime * rotspeed);
        // this is so when the object rotates to face the goal it rotates slowly instead of snapping 

        if(Vector3.Distance(lookAtGoal, transform.position) > 1) { 
        
            transform.Translate(0,0, speed * Time.deltaTime);
        }
        // this makes the object go to the goal but stops a little bit before it
        // so it doesnt get glitchy trying to be in the exact same spot as the goal
    }
}
