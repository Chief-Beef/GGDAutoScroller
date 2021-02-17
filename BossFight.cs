using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BossFight : MonoBehaviour
{

    public static BossFight Instance;

    public Quaternion badMissileRot;
    public Quaternion missileBarrageRot;

    public GameObject badMissile;
    public GameObject missileBarrage;

    public float num;
    public float num2;
    public float max = 200;
    public float powerUpChance = 100.0f;
    public float threshold = 199.0f;
    public float powerUpChanceThreshold = 99.0f;
    public float timer = .75f;
    public float reset = .75f;
    public float randomNum;


    public int health = 20;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        badMissileRot = Quaternion.Euler(-90, transform.rotation.y, transform.rotation.z);
        missileBarrageRot = Quaternion.Euler(16, 90, -90);

    }

    // Update is called once per frame
    void Update()
    {


        //Firing Mechanics
        if (timer <= 0)
        {
            num = Random.Range(0, max);
            num2 = Random.Range(0, 10);
            num2 -= 5;

            //Debug.Log(num);
            if (num > threshold)
            {
                Instantiate(badMissile, new Vector3(this.transform.position.x + num2, this.transform.position.y + 8, this.transform.position.z), badMissileRot);
            }

            timer = reset;
        }

        timer -= Time.deltaTime;

    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "rocket1")
        {
            health--;

            if (health <= 0)
            {
                Destroy(this.gameObject);

                SceneManager.LoadScene("EndCredits");
            }
        }
    }
}
