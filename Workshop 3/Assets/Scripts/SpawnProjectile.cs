using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{
    public float bulletVelocity = 100;
    public GameObject Bullet;
    public float Timer = 2;
    public Transform bulletPosition;
    private GameObject playerObj = null;
    public GameObject turret;
    public Transform player;
    private Vector3 bulletSpeed;


    void Start() { }


   
    void SpawnBullet()
    {

        bulletSpeed = (player.position - bulletPosition.position).normalized;
        GameObject bullet = Instantiate(Bullet, bulletPosition.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpeed * bulletVelocity);
        //bullet.GetComponent<Rigidbody>().transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        Object.Destroy(bullet, 3.0f);
    }
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            SpawnBullet();
            Timer = 3f;
        }
    }
}
