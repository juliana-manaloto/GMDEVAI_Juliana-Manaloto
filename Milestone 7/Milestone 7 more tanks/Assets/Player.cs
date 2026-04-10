using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public GameObject turret;

    public float health = 100;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Fire();
        }
    }
    public void Fire()
    {
        GameObject b = Instantiate(bullet, turret.transform.position, turret.transform.rotation);
        b.GetComponent<Rigidbody>().AddForce(turret.transform.forward * 500);
    }
    void OnCollisionEnter(Collision col)
    {
        Bullet bullet = col.gameObject.GetComponent<Bullet>();

        if (col != null)
        {
            health -= 20;

            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
