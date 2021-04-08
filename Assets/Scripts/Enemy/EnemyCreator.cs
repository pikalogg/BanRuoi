using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyCreator : MonoBehaviour {
    public Path[] ListPathStep1;
    public Path[] ListPathStep2;
    public Path BossPath;
    private int indexPath = 0;
    public GameObject[] Enemy;
    public GameObject Bosss;
    public GameObject Playerr;

    public GameObject[] Mess;
    private float spawnRate = 2.0f; // Bao nhiêu enemy 1 giay
    //
    private float indexEndPoints;
    float duration = 0.0f;

    //
    private float[] countEnemy = { 0.0f , 0.0f , 0.0f };

    //
    private int step = 0;
    public int maxStep;
    private float timePlayGame = 0;
    private void Awake()
    {

    }
    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // Step1
        if (Playerr.GetComponent<Player>().HP <= 0)
        {
            // thua
            if (GameObject.FindGameObjectsWithTag("Lose").Length == 0)
            {
                Playerr.GetComponent<Player>().endGame = true;
                GameObject tempMess = GameObject.Instantiate(Mess[4]);
                GameObject.FindGameObjectsWithTag("HP")[0].GetComponent<Text>().text = "0";
            }
        }
        else
        {
            GameObject.FindGameObjectsWithTag("HP")[0].GetComponent<Text>().text = Playerr.GetComponent<Player>().HP.ToString();
            if (timePlayGame == 0)
            {
                // step1
                GameObject tempMess = GameObject.Instantiate(Mess[0]);
                GameObject.Destroy(tempMess, 2.0f);
            }
            if (timePlayGame > 35.0f && timePlayGame <= 35.0f + Time.deltaTime)
            {
                // step2
                GameObject tempMess = GameObject.Instantiate(Mess[1]);
                GameObject.Destroy(tempMess, 2.0f);
            }
            if (timePlayGame > 70.0f && timePlayGame <= 70.0f + Time.deltaTime)
            {
                // boss
                GameObject tempMess = GameObject.Instantiate(Mess[2]);
                GameObject.Destroy(tempMess, 2.0f);
            }
            timePlayGame += Time.deltaTime;
            if (timePlayGame > 71.0f && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                // win
                GameObject tempMess = GameObject.Instantiate(Mess[3]);
                GameObject.Destroy(tempMess, 2.0f);
            }
            if (timePlayGame < 25.0f)
            {
                //Debug.Log("Day La Step 1\n" + GameObject.FindGameObjectsWithTag("Enemy").Length + " Enemy");
                if (countEnemy[0] < 12)
                {
                    if (duration > 1.0f / spawnRate)
                    {
                        ++countEnemy[0];
                        CreateEnemy(Enemy[1], ListPathStep1[0]);
                        CreateEnemy(Enemy[2], ListPathStep1[1]);
                        duration = 0.0f;
                    }
                    duration += Time.deltaTime;
                }
            }

            // Step2
            if (timePlayGame > 35.0f && timePlayGame < 70.0f)
            {
                //Debug.Log("Day La Step 2\n" + GameObject.FindGameObjectsWithTag("Enemy").Length + " Enemy");
                if (countEnemy[1] < 12)
                {
                    if (duration > 1.0f / spawnRate)
                    {
                        ++countEnemy[1];
                        CreateEnemy(Enemy[1], ListPathStep2[0]);
                        CreateEnemy(Enemy[2], ListPathStep2[1]);
                        if ((int)Random.Range(1.0f, 2.9f) == 1) CreateEnemy_0(Enemy[0], ListPathStep2[1]);
                        duration = 0.0f;
                    }
                    duration += Time.deltaTime;
                }
            }
            //step3
            if (timePlayGame > 70.0f)
            {
                if (countEnemy[2] < 1)
                {

                    //sinh boss
                    GameObject.Instantiate(Bosss, new Vector3(0, 6, 0), Quaternion.identity);
                    countEnemy[2]++;
                }
                //sang step 3
                //Debug.Log("Day La Step 3\n" + GameObject.FindGameObjectsWithTag("Enemy").Length + " Enemy");

            }
        }
        timePlayGame += Time.deltaTime;
    }

    void CreateEnemy(GameObject enemy, Path path)
    {
        GameObject EnemyClone = (GameObject)GameObject.Instantiate(enemy, path.ListPoints[0].position, Quaternion.identity);
        EnemyClone.GetComponent<EnemyBehavior>().MovingPath = path;
    }
    void CreateEnemy_0(GameObject enemy, Path path)
    {
        GameObject EnemyClone = (GameObject)GameObject.Instantiate(enemy, path.ListPoints[0].position, Quaternion.identity);
        EnemyClone.GetComponent<Enemy_0_Move>().MovingPath = path;
    }
}
