using UnityEngine;
using System.Collections;

public class Pickupable : Actor
{

    public override void Start()
    {
        base.Start();
        spawnPoint = transform.position;
    }

    public override void FixedUpdate()
    {
        //base.FixedUpdate();
        //if (velocity.x > speedCap.x)
        //{
        //    velocity.x = speedCap.x;
        //}
        //if (velocity.x < -speedCap.x)
        //{
        //    velocity.x = -speedCap.x;
        //}
        //if (velocity.y > speedCap.y)
        //{
        //    velocity.y = speedCap.y;
        //}
        //if (velocity.y < -speedCap.y)
        //{
        //    velocity.y = -speedCap.y;
        //}

        //velocity.x *= roll;
        velocity.y -= Globals.globals.gravity;

        if (velocity.x < 0.0001f && velocity.x > -0.0001f)
        {
            velocity.x = 0;
        }

        // Fall off screen
        if (y <= -size)
        {
            //TouchFloor(0, true);
            //TakeDamage();
            VoidOut();
        }

        // Move and Collide
        for (int i = 0; i < 4; i++)
        {
            // move
            position += (velocity / 4);
            // collide
            if (levelDataRefrence)
            {
                BlockCollision();
            }
        }
    }

    public override void TouchFloor(float _y, bool _lands)
    {
        base.TouchFloor(_y, _lands);
        if (_lands)
        {
            velocity.x *= roll;
        }
    }

}
