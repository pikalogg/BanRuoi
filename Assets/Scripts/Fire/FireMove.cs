using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMove : MonoBehaviour
{
    Transform tran;
    public float MovingSpeed;
    private void Awake()
    {
        tran = GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenInWorld = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
        tran.position += tran.up * MovingSpeed * Time.deltaTime;
        if (tran.position.y > screenInWorld.y || tran.position.y < -screenInWorld.y)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

}
