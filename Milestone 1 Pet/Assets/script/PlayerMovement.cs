using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.gameObject.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.gameObject.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime); ;
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }
}
