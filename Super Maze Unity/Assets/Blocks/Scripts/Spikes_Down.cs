using UnityEngine;
using System.Collections;

public class Spikes_Down : BlockBase
{

    public override void TouchBottom(Actor toucher)
    {
        toucher.TouchCeiling(hitbox.y1);
        //toucher.velocity.y = 0.44f;
        toucher.TakeDamage();
    }

}
