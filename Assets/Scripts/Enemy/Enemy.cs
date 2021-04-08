using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp;
    public GameObject[] Item; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            if ((int)Random.Range(0.0f, 15.0f) == 1)
            {
                int indexItem = (int)Random.Range(1.0f, 7.0f);
                if(indexItem> 3)
                {
                    indexItem = 0;
                }
                GameObject.Instantiate(Item[indexItem], gameObject.transform.position, Quaternion.identity);
            }
            GameObject.Destroy(this.gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            GameObject.Destroy(collision.gameObject);

            hp -= collision.gameObject.GetComponent<Fire>().damage;
        }
    }
}
