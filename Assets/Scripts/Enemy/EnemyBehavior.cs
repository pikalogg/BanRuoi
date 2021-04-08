using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBehavior : MonoBehaviour {
    public Path MovingPath;
    public Map MovingMap;
    //
    public float MovingSpeed;

    int CurrentPointIndex = 0;
    float MinDistanceLimit = 0.2f;


    // thời lượng tối đa giữ 1 vị trí trong Map
    float Duration = 0.0f;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (CurrentPointIndex < MovingPath.ListPoints.Count) 
        {
            //Moving
            float Distance = Vector3.Distance(new Vector3(MovingPath.ListPoints[CurrentPointIndex].position.x, MovingPath.ListPoints[CurrentPointIndex].position.y, 0.0f), new Vector3(this.transform.position.x, this.transform.position.y, 0.0f));
            this.transform.position += (MovingPath.ListPoints[CurrentPointIndex].position - this.transform.position).normalized * MovingSpeed * Time.deltaTime;
            
            //Checking End Path
            if (Distance <= MinDistanceLimit)
            {
                CurrentPointIndex++;
            }
        }
        // đi đến cuối quỹ đạo path thì tìm 1 vị trí trống trên map để vào
        else
        {
            // tìm vị trí trên mạng lưới để vào
            if (Duration <= 0.0f) 
            {
                //Moving
                List<Transform> mapPoint = GameObject.FindGameObjectsWithTag("Map")[0].GetComponent<Map>().ListPoints;
                Transform targetPoint = MovingPath.ListPoints[CurrentPointIndex - 1];

                foreach (Transform t in mapPoint)
                {
                    bool check = false;
                    //nếu điểm trên map không có enemy nào thì bay tới đó
                    GameObject[] ListEnemy = GameObject.FindGameObjectsWithTag("Enemy");
                    foreach (GameObject enemy in ListEnemy)
                    {
                        if (enemy.transform.position == t.position)
                        {
                            check = true;
                            break;
                        }
                    }
                    if (!check)
                    {
                        targetPoint = t;
                        break;
                    }
                }
                float Distance = Vector3.Distance(new Vector3(targetPoint.position.x, targetPoint.position.y, 0.0f), new Vector3(this.transform.position.x, this.transform.position.y, 0.0f));
                this.transform.position += (targetPoint.position - this.transform.position).normalized * MovingSpeed * Time.deltaTime;
                if (Distance < MinDistanceLimit)
                {
                    this.transform.position = targetPoint.position;
                    Duration = 5.0f;
                }
            }
            else
            {
                Duration -= Time.deltaTime;
            }
        }

    }
}
