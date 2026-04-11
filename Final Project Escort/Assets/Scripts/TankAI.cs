using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAI : MonoBehaviour
{
    Animator anim;

    public GameObject player;
    public GameObject bullet;
    public GameObject turret;

    public float health = 100;

    private void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetFloat("distance", Vector3.Distance(transform.position, player.transform.position));
        anim.SetFloat("health", health);

    }

   

    public void Fire()
    {
        GameObject b = Instantiate(bullet, turret.transform.position, turret.transform.rotation);
        b.GetComponent<Rigidbody>().AddForce(turret.transform.forward * 500);
    }

    public void StopFiring()
    {
        CancelInvoke("Fire");
    }

    public void StartFiring()
    {
        InvokeRepeating("Fire", 0.5f, 0.5f);
    }

    void OnCollisionEnter(Collision col)
    {
        Bullet bullet = col.gameObject.GetComponent<Bullet>();

        if (col != null)
        {
            health -= 10;

            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

 
}
