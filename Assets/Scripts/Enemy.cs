using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Camera cam;
    GameObject bots;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot(GameObject spikey)
    {

        Vector3 pos = new Vector3();
        pos = spikey.transform.position;

         GameObject bullet = GameObject.Instantiate(Resources.Load("bullet") as GameObject,pos,spikey.transform.rotation);
        // calculate the direction to the player
        Vector3 shootDirection = (cam.transform.position - pos).normalized;
        //add force rigidbody of the bullet.
        bullet.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(Random.Range(-1f,1f),Vector3.up) * shootDirection *40;

        Destroy(bullet,5f);
    }
}
