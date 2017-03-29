using UnityEngine;
using System.Collections;

public class PlayerGate : BlockBase
{

    private PlayerControl player;

    protected override void Start()
    {
        base.Start();
        player = FindObjectOfType<PlayerControl>();
    }

    public void Update()
    {
        if (player)
        {
            if (player.hitbox.Collision(hitbox))
            {
                player.touchingGate = true;
            }
        }
    }

    public override void TouchTop(Actor toucher)
    {
        if (toucher is PlayerControl)
        {
            if ((toucher as PlayerControl).isHolding)
            {
                base.TouchTop(toucher);
            }
        }
        else
        {
            base.TouchTop(toucher);
        }
    }

    public override void TouchBottom(Actor toucher)
    {
        if (toucher is PlayerControl)
        {
            if ((toucher as PlayerControl).isHolding)
            {
                base.TouchBottom(toucher);
            }
        }
        else
        {
            base.TouchBottom(toucher);
        }
    }

    public override void TouchLeft(Actor toucher)
    {
        if (toucher is PlayerControl)
        {
            if ((toucher as PlayerControl).isHolding)
            {
                base.TouchLeft(toucher);
            }
        }
        else
        {
            base.TouchLeft(toucher);
        }
    }

    public override void TouchRight(Actor toucher)
    {
        if (toucher is PlayerControl)
        {
            if ((toucher as PlayerControl).isHolding)
            {
                base.TouchRight(toucher);
            }
        }
        else
        {
            base.TouchRight(toucher);
        }
    }
    
}
