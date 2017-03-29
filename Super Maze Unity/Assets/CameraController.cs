using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    [SerializeField]
    private PlayerControl player;

    public Vector2 finalPosition = new Vector2();
    public float ease = 0.5f;

    public Vector2 finalDiff
    {
        get
        {
            return new Vector2(finalPosition.x - transform.position.x, finalPosition.y - transform.position.y);
        }
    }

	// Use this for initialization
	void Start ()
    {
        player = FindObjectOfType<PlayerControl>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (FindObjectOfType<PlayerControl>())
        {
            player = FindObjectOfType<PlayerControl>();

            float x = player.transform.position.x;
            float y = Mathf.Max(GetComponent<Camera>().orthographicSize, player.transform.position.y);
            finalPosition = new Vector2(x, y);

            transform.position = transform.position + new Vector3((finalDiff.x * ease), (finalDiff.y * ease), 0);
        }
	}
}
