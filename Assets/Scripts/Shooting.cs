using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPref;

    public float bulletForce = 20f;

    //Check every frame if the player didn't press the thing and when he did do stuff
    void Update()
    {
        processInputs();
    }

    private void FixedUpdate()
    {

    }

    //What kind of inputs we're checking
    void processInputs()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    //Create a bullet and Yeet it with bulletForce amout of force
    void Shoot()
    {
       GameObject bullet = Instantiate(bulletPref, firePoint.position, firePoint.rotation);
       Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
