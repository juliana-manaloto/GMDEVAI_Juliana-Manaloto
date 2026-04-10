
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 6;
    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;
    
    private float rotY = 0.0f; 
    private float rotX = 0.0f;
    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }
    

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
        



    }
    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            
            this.gameObject.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.gameObject.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime); ;
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
    }
}
