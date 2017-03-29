using UnityEngine;
using System.Collections;

public class FireBall : Actor
{

    private int cooldown = 0;

    [SerializeField]
    private PlayerControl player;

    public override void Start()
    {
        base.Start();

        player = FindObjectOfType<PlayerControl>();

        velocity = velocity.normalized * 0.25f;
    }

    public override void FixedUpdate()
    {
        //velocity.y -= Globals.globals.gravity;

        for (int i = 0; i < 1; i++)
        {
            // move
            position += (velocity / 1);
            // collide
            if (levelDataRefrence)
            {
                BlockCollision();
            }
        }

        //transform.Rotate(0, 0, velocity.x * 360 * size);
        if (player != null)
        {
            if (hitbox.Collision(player.hitbox) && cooldown <= 0)
            {
                player.TakeDamageSoft();
                cooldown = 60 * 3;
            }
        }
        if (cooldown > 0)
        {
            cooldown -= 1;
            GetComponent<SpriteRenderer>().color = Color.grey;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }

    }

    public override void TouchFloor(float _y, bool _lands)
    {
        //base.TouchFloor(_y, _lands);
        velocity.y *= -1;
        y = _y + (size / 2);
    }
    public override void TouchWallRight(float _x)
    {
        //base.TouchWallRight(_x);
        velocity.x *= -1;
        x = _x - (size / 2);
    }
    public override void TouchWallLeft(float _x)
    {
        //base.TouchWallLeft(_x);
        velocity.x *= -1;
        x = _x + (size / 2);
    }
    public override void TouchCeiling(float _y)
    {
        //base.TouchCeiling(_y);
        velocity.y *= -1;
        y = _y - (size / 2);
    }

    public override void TakeDamage()
    {
        //base.TakeDamage();
    }

}
