using UnityEngine;
using System.Collections;

public class RocketAI : MonoBehaviour {

    public Transform Target;

    // tọa độ đối tượng cần nhắm
    Vector3 targetPosition;

    public float MovingSpeed;

    public float RotationSpeed;

    // hướng quay của z để đầu của tên lửa (trục y) hướng về chiều dương x
    public float RotationOffset;

    // tự hủy sau khoảng thời gian
    public float Duration;
    // Use this for initialization
    void Start () {
	    if(Target == null)
        {
            targetPosition = new Vector3(0f, 7f, 0f);
        }
        else
        {
            targetPosition = Target.transform.position;
        }
	}
	
	// Update is called once per frame
	void Update () {
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, GetRotationZ()));
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);

        // di chuyển theo trục y
        this.transform.position += this.transform.up * MovingSpeed * Time.deltaTime;
        //

        try
        {
            if (Target == null)
            {
                GameObject[] ListEnemy = GameObject.FindGameObjectsWithTag("Enemy");
                Transform temp = ListEnemy[Random.Range(0, ListEnemy.Length)].transform;
                this.Target = ListEnemy[Random.Range(0, ListEnemy.Length)].transform;
                //
                targetPosition = Target.position;
            }
            else
            {
                targetPosition = Target.position;
            }
        }
        catch
        {
            targetPosition = new Vector3(0f, 7f, 0f);
        }

        //Kiểm tra xem rocket có tồn tại hơn Duration giây không
        if (Duration <= 0.0f)
        {
            GameObject.Destroy(this.gameObject);
        }
        Duration -= Time.deltaTime;
    }

    // góc quay của z để hướng tới đối tượng nhắm đến
    float GetRotationZ()
    {
        Vector3 Direction = (targetPosition - this.transform.position).normalized;
        float result = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
        return result + RotationOffset;
    }
}
