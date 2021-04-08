using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public bool endGame = false;
    Transform tran;
    SpriteRenderer spriteRenderer;
    public float speedX, speedY;
    //
    public float HP;
    //
    public GameObject Explosion;
    CreateFire createFire;
    // Loai may bay, level
    public enum Species { spaceshipRocket, spaceshipCircle, spaceshipLight };
    public GameObject[] SpaceshipRocket;
    public GameObject[] SpaceshipCircle;
    public GameObject[] SpaceshipLight;
    public Species species1;
    public int level;
    // su ly ban dan
    float[] speedShoot = {3.0f ,4.0f , 5.0f}; // tốc độ bắn đạn trong 1s của các level
    float timeCurrentShoot = 0;


    private Species Species1 { get => species1; set => species1 = value; }

    private void Awake()
    {
        tran = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        createFire = GetComponent<CreateFire>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    float timePlayGame = 0;
    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
        {
            
            Application.Quit();
            return;
        }
            int nbTouches = Input.touchCount;

            if (nbTouches > 0)
            {
                Touch myTouch = Input.GetTouch(0);
                Touch touch = Input.touches[0];
                Vector3 position = Camera.main.ScreenToWorldPoint(touch.position);
                if (tran.position.x < position.x) tran.position = new Vector3(tran.position.x + speedX * Time.deltaTime, tran.position.y, 0);
                if (tran.position.y < position.y) tran.position = new Vector3(tran.position.x, tran.position.y + speedY * Time.deltaTime, 0);
                if (tran.position.x > position.x) tran.position = new Vector3(tran.position.x - speedX * Time.deltaTime, tran.position.y, 0);
                if (tran.position.y > position.y) tran.position = new Vector3(tran.position.x, tran.position.y - speedY * Time.deltaTime, 0);
            }
        }
        
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        tran.position += new Vector3(speedX * h * Time.deltaTime, speedY * v * Time.deltaTime, 0);


        if (!endGame)
        {
            // shoot
            timeCurrentShoot += Time.deltaTime;

            // đổi tàu theo level và loại
            if (level == null || level > 2 || level < 0)
            {
                level = 0;
            }
            switch (Species1)
            {
                case Species.spaceshipCircle:
                    spriteRenderer.sprite = SpaceshipCircle[level].GetComponent<SpriteRenderer>().sprite;
                    spriteRenderer.color = SpaceshipCircle[level].GetComponent<SpriteRenderer>().color;
                    if (timeCurrentShoot >= 1.0f / speedShoot[level])
                    {
                        //bắn đạn tỏa
                        createFire.Radiate(level);
                        timeCurrentShoot = 0;
                    }
                    break;
                case Species.spaceshipLight:
                    spriteRenderer.sprite = SpaceshipLight[level].GetComponent<SpriteRenderer>().sprite;
                    spriteRenderer.color = SpaceshipLight[level].GetComponent<SpriteRenderer>().color;
                    if (timeCurrentShoot >= 1.0f / speedShoot[level])
                    {
                        //đạn bay thẳng
                        createFire.Light(level);
                        timeCurrentShoot = 0;
                    }
                    break;
                case Species.spaceshipRocket:
                    spriteRenderer.sprite = SpaceshipRocket[level].GetComponent<SpriteRenderer>().sprite;
                    spriteRenderer.color = SpaceshipRocket[level].GetComponent<SpriteRenderer>().color;
                    if (timeCurrentShoot >= 1.0f / speedShoot[level])
                    {
                        //đạn truy đuổi
                        createFire.Rocket(level);
                        timeCurrentShoot = 0;
                    }
                    break;
                default:
                    break;
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject explosionClone = GameObject.Instantiate(Explosion);
            explosionClone.transform.position = tran.position;
            GameObject.Destroy(explosionClone, 1.08f);
            GameObject.Destroy(collision.gameObject);
            HP--;
            level = 0;
            tran.position = new Vector3(0, -4, 0);
        }
        if (collision.gameObject.tag == "Boss")
        {
            GameObject explosionClone = GameObject.Instantiate(Explosion);
            explosionClone.transform.position = tran.position;
            GameObject.Destroy(explosionClone, 1.08f);
            HP--;
            level = 0;
            tran.position = new Vector3(0, -4, 0);
        }
        if (collision.gameObject.tag == "Item")
        {
            int index = collision.gameObject.GetComponent<Item>().indexItem;
            switch (index)
            {
                case 0:
                    if (level < 2) level++;
                    break;
                case 1:
                    species1 = Species.spaceshipLight;
                    break;
                case 2:
                    species1 = Species.spaceshipCircle;
                    break;
                case 3:
                    species1 = Species.spaceshipRocket;
                    break;
                default:
                    break;
            }
            GameObject.Destroy(collision.gameObject);
        }
    }
}
