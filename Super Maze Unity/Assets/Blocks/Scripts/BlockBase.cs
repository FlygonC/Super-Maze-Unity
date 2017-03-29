using UnityEngine;
using System.Collections;

public enum Solidity { Solid, Soft, }

public enum Side { Top = 0, Right, Bottom, Left }

[ExecuteInEditMode]
public class BlockBase : MonoBehaviour {

    //[HideInInspector]
    public int x, y;
    public int width = 1, height = 1;
    public bool active = true;

    //public AABBCollider TESTshowBox;
    //public Side TESTside;

    public virtual AABBCollider hitbox
    {
        get
        {
            return AABBCollider.MakeBoxBLCorner(x, y, width, height);
        }
    }
    
    public virtual void TouchTop(Actor toucher)
    {
        toucher.TouchFloor(hitbox.y2, true);
    }
    public virtual void TouchBottom(Actor toucher)
    {
        toucher.TouchCeiling(hitbox.y1);
    }
    public virtual void TouchLeft(Actor toucher)
    {
        toucher.TouchWallRight(hitbox.x1);
    }
    public virtual void TouchRight(Actor toucher)
    {
        toucher.TouchWallLeft(hitbox.x2);
    }

    protected virtual void Start()
    {
        //gameObject.name = "";
        //gameObject.name = this.ToString() + " " + transform.position.x + ", " + transform.position.y;
        x = Mathf.FloorToInt(transform.position.x);
        y = Mathf.FloorToInt(transform.position.y);
        transform.position = new Vector3(x, y, 1);

        //width = Mathf.FloorToInt(transform.localScale.x);
        //height = Mathf.FloorToInt(transform.localScale.y);
        //transform.localScale = new Vector3(width, height, 1);

        //TESTshowBox = hitbox;
        //TESTside = FindNearestSide(FindObjectOfType<PlayerControl>().GetComponent<Actor>().position);
    }

    /*public virtual void Update()
    {
        //TESTside = FindNearestSide(FindObjectOfType<PlayerControl>().GetComponent<Actor>().position);
    }*/

    [ContextMenu("SetBlock")]
    public void SetBlock()
    {
        x = Mathf.RoundToInt( transform.position.x);
        y = Mathf.RoundToInt(transform.position.y);
        transform.position = new Vector3(x, y, -1);
    }

    public Side FindNearestSide(Vector2 _spot)
    {
        float y = 0;
        if (_spot.y > hitbox.y2)
        {
            y = _spot.y - hitbox.y2;
        }
        if (_spot.y < hitbox.y1)
        {
            y = _spot.y - hitbox.y1;
        }
        float x = 0;
        if (_spot.x > hitbox.x2)
        {
            x = _spot.x - hitbox.x2;
        }
        if (_spot.x < hitbox.x1)
        {
            x = _spot.x - hitbox.x1;
        }

        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            if (x > 0)
            {
                return Side.Right;
            }
            else
            {
                return Side.Left;
            }
        }
        else
        {
            if (y > 0)
            {
                return Side.Top;
            }
            else
            {
                return Side.Bottom;
            }
        }
        
    }

}
