using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Path MovingPath;
    //
    public float MovingSpeed;

    int CurrentPointIndex = 0;
    float MinDistanceLimit = 0.2f;

    public float HP;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (HP <= 0)
        {
            GameObject.Destroy(this.gameObject);
        }

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
            CurrentPointIndex-=2;
            MovingSpeed = 1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            GameObject.Destroy(collision.gameObject);

            HP -= collision.gameObject.GetComponent<Fire>().damage;
        }
    }
}
