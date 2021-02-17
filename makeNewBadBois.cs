using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class makeNewBadBois : MonoBehaviour
{

    //public GameObject[,] enemies = new GameObject[6,7];
    public GameObject[] enemy1 = new GameObject [7];
    public GameObject[] enemy2 = new GameObject [7];
    public GameObject[] enemy3 = new GameObject [7];
    public GameObject[] enemy4 = new GameObject [7];
    public GameObject[] enemy5 = new GameObject [7];
    public GameObject[] enemy6 = new GameObject [7];
    public GameObject[] boss = new GameObject[1];

    public GameObject player;

    public GameObject enemyGroup1;
    public GameObject enemyGroup2;
    public GameObject enemyGroup3;
    public GameObject enemyGroup4;
    public GameObject enemyGroup5;
    public GameObject enemyGroup6;
    public GameObject bossFight;

    public bool testBool;

    public float zMov;
    public float xMov;
    public float xSpeed = 10.0f;
    public float zSpeed = -10.0f;
    public float activeFormation = 0;
    public float minZ;

    public Vector3 minBounds;
    public Vector3 maxBounds;

    // Start is called before the first frame update
    void Start()
    {

        enemyGroup1.SetActive(true);
        enemyGroup2.SetActive(false);
        enemyGroup3.SetActive(false);
        enemyGroup4.SetActive(false);
        enemyGroup5.SetActive(false);
        enemyGroup6.SetActive(false);
        bossFight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        zMov = this.transform.position.z;
        zMov += zSpeed * Time.deltaTime;

        xMov = this.transform.position.x;
        xMov += xSpeed * Time.deltaTime;

        if (xMov <= minBounds.x || xMov >= maxBounds.x)
            xSpeed *= -1;

        if (CheckFighters(enemy1))
        {
            enemyGroup2.SetActive(true);
            activeFormation = 1;
        }

        if(CheckFighters(enemy2))
        {
            enemyGroup3.SetActive(true);
            activeFormation = 2;
        }

        if (CheckFighters(enemy3))
        {
            enemyGroup4.SetActive(true);
            activeFormation = 3;
        }

        if (CheckFighters(enemy4))
        {
            enemyGroup5.SetActive(true);
            activeFormation = 4;
        }

        if (CheckFighters(enemy5))
        {
            enemyGroup6.SetActive(true);
            activeFormation = 5;
        }

        if (CheckFighters(enemy6))
        {
            bossFight.SetActive(true);
            activeFormation = 6;
        }


        this.transform.position = new Vector3(xMov, this.transform.position.y, zMov);


        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minBounds.x, maxBounds.x),
            Mathf.Clamp(transform.position.y, minBounds.y, maxBounds.y),
            Mathf.Clamp(transform.position.z, minBounds.z - (150 * activeFormation), maxBounds.z));

        if (player == null)
            SceneManager.LoadScene("LoseCredits");
        else if (boss == null)
            SceneManager.LoadScene("EndCredits");

    }

    public bool CheckFighters(GameObject[] enemies)
    {
        for(int i = 0; i < 7; i ++)
        {
            if(enemies[i] != null)
            {
                return false;
            }
        }

        return true;
    }

}



