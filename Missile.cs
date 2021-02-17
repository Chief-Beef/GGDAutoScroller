using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public GameObject explosion;
    public Rigidbody rb;
    public float speed = 10f;
    public float accelerator = 2.0f;
    public float maxTime = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector3(0, 0, speed);

        //rb.AddForce(thrust, ForceMode.Acceleration);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0, 0, speed);
        speed += accelerator;

        maxTime -= Time.deltaTime;

        if(maxTime <= 0)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "enemy")
        {
            Debug.Log("Boom Shakalaka #RipMamba");
            Instantiate(explosion, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            Destroy(this.gameObject);
            
        }
    }
}
