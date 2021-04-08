using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {
    [HideInInspector]
    public Vector3 MaxPoint;
    [HideInInspector]
    public Vector3 MinPoint;
	// Use this for initialization
	void Start () {
        MaxPoint = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0.0f));
        MinPoint = Camera.main.ScreenToWorldPoint(Vector3.zero);
        float WidthScreen = MaxPoint.x - MinPoint.x;
        float HeightScreen = MaxPoint.y - MinPoint.y;
        //
        float pixelPerUnit = this.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
        Vector3 sizeOfSprite = new Vector3(this.GetComponent<SpriteRenderer>().sprite.rect.width, this.GetComponent<SpriteRenderer>().sprite.rect.height, 0.0f);
        //
        Vector3 scaleOfBackground = new Vector3(WidthScreen / (sizeOfSprite.x / pixelPerUnit), HeightScreen / (sizeOfSprite.y / pixelPerUnit), 0.0f);

        this.transform.localScale = scaleOfBackground;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
