using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFire : MonoBehaviour
{
    public GameObject _radiate, _light, _rocket; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Radiate(int level)
    {
        switch (level)
        {
            case 0:
                Radiate_0();
                break;
            case 1:
                Radiate_1();
                break;
            case 2:
                Radiate_2();
                break;
            default:
                break;
        }
    }
    public void Light(int level)
    {
        switch (level)
        {
            case 0:
                Light_0();
                break;
            case 1:
                Light_1();
                break;
            case 2:
                Light_2();
                break;
            default:
                break;
        }
    }
    public void Rocket(int level)
    {
        switch (level)
        {
            case 0:
                Rocket_0();
                break;
            case 1:
                Rocket_1();
                break;
            case 2:
                Rocket_2();
                break;
            default:
                break;
        }
    }


    private void Radiate_0()
    {
        Vector3 positionClone = Vector3.zero;
        try { positionClone = GameObject.FindGameObjectsWithTag("Player")[0].transform.position; }
        catch { }
        GameObject FireClone = (GameObject)GameObject.Instantiate(_radiate, positionClone, Quaternion.identity);
    }
    private void Radiate_1()
    {
        Vector3 positionClone = Vector3.zero;
        try { positionClone = GameObject.FindGameObjectsWithTag("Player")[0].transform.position; }
        catch { }
        GameObject FireClone1 = (GameObject)GameObject.Instantiate(_radiate);
        FireClone1.transform.position = new Vector3(positionClone.x - 0.1f, positionClone.y, 0.0f);
        FireClone1.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 5.0f));
        GameObject FireClone2 = (GameObject)GameObject.Instantiate(_radiate);
        FireClone2.transform.position = new Vector3(positionClone.x + 0.1f, positionClone.y, 0.0f);
        FireClone2.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -5.0f));
    }
    private void Radiate_2()
    {
        Vector3 positionClone = Vector3.zero;
        try { positionClone = GameObject.FindGameObjectsWithTag("Player")[0].transform.position; }
        catch { }
        GameObject FireClone = (GameObject)GameObject.Instantiate(_radiate, positionClone, Quaternion.identity);
        GameObject FireClone1 = (GameObject)GameObject.Instantiate(_radiate);
        FireClone1.transform.position = new Vector3(positionClone.x - 0.1f, positionClone.y, 0.0f);
        FireClone1.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 7.0f));
        GameObject FireClone2 = (GameObject)GameObject.Instantiate(_radiate);
        FireClone2.transform.position = new Vector3(positionClone.x + 0.1f, positionClone.y, 0.0f);
        FireClone2.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -7.0f));
    }

    private void Light_0()
    {
        Vector3 positionClone = Vector3.zero;
        try { positionClone = GameObject.FindGameObjectsWithTag("Player")[0].transform.position; }
        catch { }
        GameObject FireClone = (GameObject)GameObject.Instantiate(_light, positionClone , Quaternion.identity);
    }
    private void Light_1()
    {
        Vector3 positionClone = Vector3.zero;
        try { positionClone = GameObject.FindGameObjectsWithTag("Player")[0].transform.position; }
        catch { }
        GameObject FireClone1 = (GameObject)GameObject.Instantiate(_light);
        FireClone1.transform.position = new Vector3(positionClone.x - 0.1f, positionClone.y, 0.0f);
        GameObject FireClone2 = (GameObject)GameObject.Instantiate(_light);
        FireClone2.transform.position = new Vector3(positionClone.x + 0.1f, positionClone.y, 0.0f);
    }
    private void Light_2()
    {
        Vector3 positionClone = Vector3.zero;
        try { positionClone = GameObject.FindGameObjectsWithTag("Player")[0].transform.position; }
        catch { }
        GameObject FireClone = (GameObject)GameObject.Instantiate(_light, positionClone, Quaternion.identity);
        GameObject FireClone1 = (GameObject)GameObject.Instantiate(_light);
        FireClone1.transform.position = new Vector3(positionClone.x - 0.2f, positionClone.y, 0.0f);
        GameObject FireClone2 = (GameObject)GameObject.Instantiate(_light);
        FireClone2.transform.position = new Vector3(positionClone.x + 0.2f, positionClone.y, 0.0f);
    }

    private void Rocket_0()
    {
        Vector3 positionClone = Vector3.zero;
        try { positionClone = GameObject.FindGameObjectsWithTag("Player")[0].transform.position; }
        catch { }
        GameObject FireClone = (GameObject)GameObject.Instantiate(_rocket, positionClone, Quaternion.identity);
    }
    private void Rocket_1()
    {
        Vector3 positionClone = Vector3.zero;
        try { positionClone = GameObject.FindGameObjectsWithTag("Player")[0].transform.position; }
        catch { }
        GameObject FireClone1 = (GameObject)GameObject.Instantiate(_rocket);
        FireClone1.transform.position = new Vector3(positionClone.x - 0.1f, positionClone.y, 0.0f);
        GameObject FireClone2 = (GameObject)GameObject.Instantiate(_rocket);
        FireClone2.transform.position = new Vector3(positionClone.x + 0.1f, positionClone.y, 0.0f);
    }
    private void Rocket_2()
    {
        Vector3 positionClone = Vector3.zero;
        try { positionClone = GameObject.FindGameObjectsWithTag("Player")[0].transform.position; }
        catch { }
        GameObject FireClone = (GameObject)GameObject.Instantiate(_rocket, positionClone, Quaternion.identity);
        GameObject FireClone1 = (GameObject)GameObject.Instantiate(_rocket);
        FireClone1.transform.position = new Vector3(positionClone.x - 0.15f, positionClone.y, 0.0f);
        GameObject FireClone2 = (GameObject)GameObject.Instantiate(_rocket);
        FireClone2.transform.position = new Vector3(positionClone.x + 0.15f, positionClone.y, 0.0f);
    }
}
