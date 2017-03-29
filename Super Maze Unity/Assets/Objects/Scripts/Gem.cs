using UnityEngine;
using System.Collections;

public class Gem : MonoBehaviour {

    AABBCollider hitbox
    {
        get
        {
            return AABBCollider.MakeBoxCenter(transform.position.x, transform.position.y, 1, 1);
        }
    }

    private LevelObject level;

    private PlayerControl player;

    // Use this for initialization
    void Start()
    {
        if (FindObjectOfType<LevelObject>())
        {
            level = FindObjectOfType<LevelObject>();
            level.maxGems++;
        }
        player = FindObjectOfType<PlayerControl>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (player != null)
        {
            if (hitbox.Collision(player.hitbox))
            {
                level.collectedGems++;
                Destroy(gameObject);
            }
        }
    }
}
