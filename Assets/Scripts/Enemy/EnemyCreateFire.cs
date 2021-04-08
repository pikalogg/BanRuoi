using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreateFire : MonoBehaviour
{
    public GameObject Fire;
    private float Duration = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Duration -= Time.deltaTime;
        if (Duration <= 0)
        {
            if ((int)Random.Range(0.0f, 9.9f) == 3)
            {
                GameObject.Instantiate(Fire).transform.position = this.transform.position;
            }
            Duration = 0.5f;
        }
        
    }
}
