using UnityEngine;
using System.Collections;

public class TriCrystal : MonoBehaviour {

    [SerializeField]
    private LevelObject level;
    [SerializeField]
    private SpriteRenderer sprite;
    private PlayerControl player;

    [SerializeField]
    private Sprite blue;
    [SerializeField]
    private Sprite green;

    public AABBCollider hitbox
    {
        get
        {
            return AABBCollider.MakeBoxBLCorner(transform.position.x, transform.position.y, 2, 1);
        }
    }

	// Use this for initialization
	void Start ()
    {
        level = FindObjectOfType<LevelObject>();
        sprite = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<PlayerControl>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (level.triState)
        {
            sprite.sprite = blue;

            if (player)
            {
                if (hitbox.Collision(player.hitbox) && Input.GetButtonDown("Activate"))
                {
                    level.triState = false;
                }
            }
        } else {
            sprite.sprite = green;

            if (player)
            {
                if (hitbox.Collision(player.hitbox) && Input.GetButtonDown("Activate"))
                {
                    level.triState = true;
                }
            }
        }
    }
}
