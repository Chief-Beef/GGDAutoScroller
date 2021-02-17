using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 minBounds;
    public Vector3 maxBounds;
    public Vector3 missilePos;

    public Quaternion missileRot; 

    public GameObject missile;
    
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;
    public KeyCode space;

    public float xMov;
    public float zMov;
    public float speed = 25;
    public float shotClock = .25f;
    public float shotTotal;
    public float powerUpTimer = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        missileRot = Quaternion.Euler(90, transform.rotation.y, transform.rotation.z);
        shotTotal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Reset values to current position so that you do not move at the speed of light
        zMov = this.transform.position.z;
        xMov = this.transform.position.x;

        if(shotClock < .25f)
        {
            powerUpTimer -= Time.deltaTime;
        }



        //Forward and backwards movement
        if (Input.GetKey(up))
        {
            zMov += speed*Time.deltaTime;
        }

        if (Input.GetKey(down))
        {
            zMov -= speed*Time.deltaTime;
        }

        //Left and right movement
        if (Input.GetKey(right))
        {
            xMov += speed*Time.deltaTime;
        }

        if (Input.GetKey(left))
        {
            xMov -= speed*Time.deltaTime;
        }

        this.transform.position = new Vector3(xMov, this.transform.position.y, zMov);

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minBounds.x, maxBounds.x),
            Mathf.Clamp(transform.position.y, minBounds.y, maxBounds.y),
            Mathf.Clamp(transform.position.z, minBounds.z, maxBounds.z));
        //End Movement Section of Script

        shotTotal %= 2; 

        missilePos = new Vector3(this.transform.position.x -3 + shotTotal*6 , this.transform.position.y - 2 , this.transform.position.z);
        

        if (Input.GetKeyDown(space) && shotClock <= 0)
        {
            Instantiate(missile, missilePos, missileRot);
            if(powerUpTimer <= 0)
                shotClock = .25f;
            //shotClock = 0;
            shotTotal++;
        }

        shotClock -= Time.deltaTime;


    }

    public void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "badRocket1")
        {
            Destroy(this.gameObject);

        }

        if(col.gameObject.tag == "missileBarrage")
        {
            powerUpTimer = 4.0f;
        }
    }
}
