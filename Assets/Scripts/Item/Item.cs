using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int indexItem;
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
        Vector3 _screen = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0.0f));
        tran.position -= tran.up * MovingSpeed * Time.deltaTime;
        if (tran.position.y < -_screen.y)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
