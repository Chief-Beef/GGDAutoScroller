using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadMissile : MonoBehaviour
{

    public Rigidbody brb;

    public GameObject explosion;

    public float badSpeed = -10.0f;
    public float badAccel = -2.0f;
    public float maxTimer = 4.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        brb.velocity = new Vector3(0, 0, badSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        //maybe accelerator
        brb.velocity = new Vector3(0, 0, badSpeed);
        // no accelerator

        maxTimer -= Time.deltaTime;
        if (maxTimer <= 0)
            Destroy(this.gameObject);

    }

    public void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            Instantiate(explosion, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
