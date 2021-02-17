using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudmove : MonoBehaviour
{

    public float speed = 5.0f;
    public float zMov;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        zMov = 0;
        zMov = this.transform.position.z - (speed * Time.deltaTime);

        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, zMov);
    }
}
