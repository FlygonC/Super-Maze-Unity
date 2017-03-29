using UnityEngine;
using System.Collections;

public class Treadmill : BlockBase
{

    public float speed;
    public bool right = false;

    public override void TouchTop(Actor toucher)
    {
        base.TouchTop(toucher);
        if (right)
        {
            toucher.velocity.x += speed;
        }
        else
        {
            toucher.velocity.x -= speed;
        }
    }

}
