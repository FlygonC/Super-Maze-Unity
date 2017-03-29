using UnityEngine;
using System.Collections;

public class Spikes_Left : BlockBase
{

    public override void TouchLeft(Actor toucher)
    {
        toucher.TouchWallRight(hitbox.x1);
        //toucher.velocity.y = 0.44f;
        toucher.TakeDamage();
    }

}