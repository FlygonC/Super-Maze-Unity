using UnityEngine;
using System.Collections;

public class FallAwayBlock : BlockBase {

    public bool breaking = false;
    public int breakTime = 0;

    void FixedUpdate()
    {
        if (breaking)
        {
            breakTime++;
            if (breakTime > 30 + (60 * 3))
            {
                breakTime = 0;
                breaking = false;
            }
            else
            if (breakTime > 30)
            {
                GetComponent<Animator>().Play("FallAway_Gone");
                active = false;
            }
            else if (breakTime > 0)
            {
                GetComponent<Animator>().Play("FallAway_Break");
            }
            
            
        }
        else
        {
            GetComponent<Animator>().Play("FallAway_Still");
            active = true;
        }
    }

    public override void TouchTop(Actor toucher)
    {
        base.TouchTop(toucher);
        breaking = true;
    }
}
