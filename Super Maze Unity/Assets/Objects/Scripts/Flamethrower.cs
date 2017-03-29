using UnityEngine;
using System.Collections;

public class Flamethrower : MonoBehaviour {

    [SerializeField]
    private Sprite unlit;
    [SerializeField]
    private Sprite phase1;
    [SerializeField]
    private Sprite phase2;
    [SerializeField]
    private Sprite phase3;

    public int charge;
    public float range = 10;

    private PlayerControl player;
    [SerializeField]
    private FlameThrow flame;

    // Use this for initialization
    void Start ()
    {
        player = FindObjectOfType<PlayerControl>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
	    if (charge < 180)
        {
            charge++;
            if (charge >= 0)
            {
                GetComponent<SpriteRenderer>().sprite = phase1;
            }
            if (charge >= 60)
            {
                GetComponent<SpriteRenderer>().sprite = phase2;
            }
            if (charge >= 120)
            {
                GetComponent<SpriteRenderer>().sprite = phase3;
            }
        }

        if (player != null)
        {
            //player = FindObjectOfType<PlayerControl>();
            if (charge >= 180 && (player.position - (Vector2)transform.position).magnitude < range)
            {
                Instantiate(flame, transform.position, transform.rotation);
                charge = -180;
                GetComponent<SpriteRenderer>().sprite = unlit;
            }
        }
	}
}
