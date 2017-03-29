using UnityEngine;
using System.Collections;

public class MeanGhost : Actor
{

    public float speed = 0.05f;
    public float range = 7;
    public int cooldown = 0;

    [SerializeField]
    private Sprite neutral;
    [SerializeField]
    private Sprite chase;
    [SerializeField]
    private Sprite cooling;

    private PlayerControl player;

    public override void Start()
    {
        base.Start();
        player = FindObjectOfType<PlayerControl>();
        spawnPoint = transform.position;
    }


    public override void FixedUpdate()
    {
        //base.FixedUpdate();

        GetComponent<SpriteRenderer>().sprite = neutral;
        if (cooldown > 0)
        {
            cooldown--;
            GetComponent<SpriteRenderer>().sprite = cooling;
        }

        if (player != null)
        {
            //player = FindObjectOfType<PlayerControl>();
            if ((player.position - spawnPoint).magnitude < range && cooldown <= 0)
            {
                velocity = (player.position - position).normalized * speed;
                position += velocity;
                GetComponent<SpriteRenderer>().sprite = chase;
            }
            else
            {
                if (speed > (spawnPoint - position).magnitude)
                {
                    position = spawnPoint;
                }
                else
                {
                    velocity = (spawnPoint - position).normalized * speed;
                    position += velocity;
                }
            }
        }

        if (hitbox.Collision(player.hitbox) && cooldown <= 0)
        {
            player.TakeDamageSoft();
            cooldown = 60 * 3;
        }
    }
}
