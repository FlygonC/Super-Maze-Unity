using UnityEngine;
using System.Collections;

public class Spikes_Right : BlockBase
{

    public override void TouchRight(Actor toucher)
    {
        toucher.TouchWallLeft(hitbox.x2);
        //toucher.velocity.y = 0.44f;
        toucher.TakeDamage();
    }

}