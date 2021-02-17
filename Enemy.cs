using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Quaternion badMissileRot;
    public Quaternion missileBarrageRot;

    public GameObject badMissile;
    public GameObject missileBarrage;

    public float num;
    public float max = 500.0f;
    public float powerUpChance = 100.0f;
    public float threshold = 499.0f;
    public float powerUpChanceThreshold = 99.0f;
    public float timer = 2.0f;
    public float reset = 2.0f;
    public float randomNum;


    // Start is called before the first frame update
    void Start()
    {
        badMissileRot = Quaternion.Euler(-90, transform.rotation.y, transform.rotation.z);
        missileBarrageRot = Quaternion.Euler(16,90,-90);

    }

    // Update is called once per frame
    void Update()
    {


        //Firing Mechanics
        if(timer <= 0)
        {
            num = Random.Range(0, max);
            //Debug.Log(num);
            if (num > threshold)
            {

                randomNum = Random.Range(0, powerUpChance);
                if (randomNum > powerUpChanceThreshold)
                {
                    Instantiate(missileBarrage, new Vector3(this.transform.position.x, this.transform.position.y + 3, this.transform.position.z), badMissileRot);
                    Debug.Log(randomNum);
                }
                else
                {
                    Instantiate(badMissile, new Vector3(this.transform.position.x, this.transform.position.y + 3, this.transform.position.z), badMissileRot);
                }
            }

        timer = reset;
        }

        timer -= Time.deltaTime;

    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "rocket1")
        {
            
            Destroy(this.gameObject);
        }
    }
}
