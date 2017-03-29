using UnityEngine;
using System.Collections;

public class RubberBrick : BlockBase
{

    private float sideLift = 0.35f;
    private float sideBounce = 0.35f;
    private int stunTime = 0;

    public override void TouchTop(Actor toucher)
    {
        base.TouchTop(toucher);
        //toucher.TouchFloor(hitbox.y2, false);
        if (!(toucher is FireBall))
        {
            toucher.velocity.y = 0.44f;
        }
    }
    public override void TouchBottom(Actor toucher)
    {
        base.TouchBottom(toucher);
        toucher.velocity.y = -0.44f;
    }
    public override void TouchRight(Actor toucher)
    {
        base.TouchRight(toucher);
        toucher.velocity.x = sideBounce;
        toucher.velocity.y = Mathf.Max(sideLift, toucher.velocity.y);
        if (toucher is PlayerControl)
        {
            (toucher as PlayerControl).canjump = false;
            (toucher as PlayerControl).acceleration = (toucher as PlayerControl).maxSpeed;
            (toucher as PlayerControl).right = true;
        }
    }
    public override void TouchLeft(Actor toucher)
    {
        base.TouchLeft(toucher);
        toucher.velocity.x = -sideBounce;
        toucher.velocity.y = Mathf.Max(sideLift, toucher.velocity.y);
        if (toucher is PlayerControl)
        {
            (toucher as PlayerControl).canjump = false;
            (toucher as PlayerControl).acceleration = (toucher as PlayerControl).maxSpeed;
            (toucher as PlayerControl).right = false;
        }
    }

}
