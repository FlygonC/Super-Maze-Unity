using UnityEngine;
using System.Collections;

public class DeathShard : Actor {

    public int selfKill = -1;

    public override void Start()
    {
        base.Start();

        Vector2 angle = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-0.5f, 1.5f));
        angle = angle.normalized;

        float speed = Random.Range(0.0f, 0.8f);

        velocity.x = angle.x * speed;
        velocity.y = angle.y * speed;

        roll = 1;
    }

    public override void FixedUpdate()
    {
        velocity.y -= Globals.globals.gravity;
        
        // move
        position += velocity;
        // collide
        if (levelDataRefrence)
        {
            BlockCollision();
        }

        transform.Rotate(0, 0, -velocity.x * 360 * size);

        // Fall off screen
        if (y <= -size)
        {
            VoidOut();
        }

        if (selfKill > 0)
        {
            selfKill--;
            if (selfKill == 0)
            {
                Destroy(gameObject);
            }
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

    public override void VoidOut()
    {
        Destroy(gameObject);
    }

    public override void TakeDamage()
    {
        //base.TakeDamage();
        //Destroy(gameObject);
    }
}
