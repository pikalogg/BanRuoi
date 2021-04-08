using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public Color PointColor = Color.white;
    //
    public List<Transform> ListPoints = new List<Transform>();

    void OnDrawGizmos()
    {
        Gizmos.color = PointColor;
        ListPoints.Clear();
        //
        foreach (Transform t in this.GetComponentsInChildren<Transform>())
        {
            if (t != this.transform)
            {
                ListPoints.Add(t);
            }
        }
        //
        for (int i = 0; i < ListPoints.Count; i++)
        {
                Gizmos.color = PointColor;
                Gizmos.DrawSphere(ListPoints[i].position, 0.15f);
        }
    }
}
