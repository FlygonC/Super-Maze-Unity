using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Snap : MonoBehaviour {

    [HideInInspector]
    public int x, y;
    public float offsetX = 0.5f, offsetY = 0.5f;
    public bool SnapScale = false;
    [HideInInspector]
    public int width, height;

    // Use this for initialization
    void Start ()
    {
        Destroy(this);
	}
	
	// Update is called once per frame
	void Update ()
    {
        x = Mathf.FloorToInt(transform.position.x);
        y = Mathf.FloorToInt(transform.position.y);
        transform.position = new Vector3(x + offsetX, y + offsetY, 1);
        if (SnapScale)
        {
            width = Mathf.FloorToInt(transform.localScale.x);
            height = Mathf.FloorToInt(transform.localScale.y);
            transform.localScale = new Vector3(width + offsetX, height + offsetY, 1);
        }
    }
}
