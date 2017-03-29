using UnityEngine;
using System.Collections;

public class LockBlock : BlockBase {

    [SerializeField]
    private Sprite openSprite;

    public override void TouchTop(Actor toucher)
    {
        base.TouchTop(toucher);
        if (CheckKey(toucher))
        {
            Unlock();
        }
    }
    public override void TouchBottom(Actor toucher)
    {
        base.TouchBottom(toucher);
        if (CheckKey(toucher))
        {
            Unlock();
        }
    }
    public override void TouchRight(Actor toucher)
    {
        base.TouchRight(toucher);
        if (CheckKey(toucher))
        {
            Unlock();
        }
    }
    public override void TouchLeft(Actor toucher)
    {
        base.TouchLeft(toucher);
        if (CheckKey(toucher))
        {
            Unlock();
        }
    }

    private bool CheckKey(Actor _toucher)
    {
        if (_toucher is PlayerControl)
        {
            if ((_toucher as PlayerControl).heldItem is Key)
            {
                return true;
            }
        }
        if (_toucher is Key)
        {
            return true;
        }
        
        return false;
    }
    public void Unlock()
    {
        GetComponent<SpriteRenderer>().sprite = openSprite;
        active = false;
    }
}
