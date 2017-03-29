using UnityEngine;
using System.Collections;

public class Finish : MonoBehaviour
{

    private PlayerControl player;
    private PlayManager manager;

    public virtual AABBCollider hitbox
    {
        get
        {
            return AABBCollider.MakeBoxCenter(transform.position.x, transform.position.y, 2, 2);
        }
    }

    // Use this for initialization
    void Start ()
    {
        player = FindObjectOfType<PlayerControl>();
        manager = FindObjectOfType<PlayManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (player)
        {
            if (hitbox.Collision(player.hitbox))
            {
                if (manager)
                {
                    manager.FinishLevel();
                }
            }
        }
    }
}
