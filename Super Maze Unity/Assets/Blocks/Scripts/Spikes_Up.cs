using UnityEngine;
using System.Collections;

public class Spikes_Up : BlockBase
{

    public override void TouchTop(Actor toucher)
    {
        toucher.TouchFloor(hitbox.y2, true);
        //toucher.velocity.y = 0.44f;
        toucher.TakeDamage();
    }

}
