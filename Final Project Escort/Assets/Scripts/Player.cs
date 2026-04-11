
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public GameObject turret;
    
    public Image win;
    public Image lose;
    public float health = 100;
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        transform.Rotate(0, h, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
        if(this.transform.position.x >= 7 )
        {
            win.gameObject.SetActive(true);
            Destroy(this);
        }
    }
    public void Fire()
    {
        GameObject b = Instantiate(bullet, turret.transform.position, turret.transform.rotation);
        b.GetComponent<Rigidbody>().AddForce(turret.transform.forward * 500);
        Destroy(b, 7);
    }
    void OnCollisionEnter(Collision col)
    {
        Bullet bullet = col.gameObject.GetComponent<Bullet>();
        Debug.Log("hmm");
        if (col != null)
        {
            health -= 20;

            if (health <= 0)
            {
                lose.gameObject.SetActive(true);
                Destroy(this.gameObject);
            }
        }

        if(col.gameObject.tag == "Agent")
        {
            health -= 5;

            if (health <= 0)
            {
                lose.gameObject.SetActive(true);
                Destroy(this.gameObject);
            }
        }

        
    }
    
}
