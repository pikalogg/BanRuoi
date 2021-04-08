using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_0_Move : MonoBehaviour
{
    Transform tran;
    public Path MovingPath;
    //
    public float MovingSpeed;

    int CurrentPointIndex = 0;
    float MinDistanceLimit = 0.2f;
    private void Awake()
    {
        tran = GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float vx = 3;
    float vy = 0;
    // Update is called once per frame
    void FixedUpdate()
    {
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
        else
        {
            Vector3 _screen = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0.0f));
            int v = (int)Random.Range(0, 500);
            if (v == 0) { vx = 3; vy = 0; }
            if (v == 1) { vx = -3; vy = 0; }
            if (v == 2) { vy = 3; vx = 0; }
            if (v == 3) { vy = -3; vx = 0; }


            if (tran.position.x > _screen.x) { vx = -3; vy = 0; }
            if (tran.position.x < -_screen.x) { vx = 3; vy = 0; }
            if (tran.position.y > _screen.y) { vy = -3; vx = 0; }
            if (tran.position.y < -_screen.y) GameObject.Destroy(this.gameObject);

            tran.position = new Vector3(tran.position.x + vx * Time.deltaTime, tran.position.y + vy * Time.deltaTime, 0);
        }
    }
}
