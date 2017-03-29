using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Actor : MonoBehaviour {

    protected LevelObject levelDataRefrence;

    public Vector2 position
    {
        get
        {
            return (Vector2)this.transform.position;
        }
        set
        {
            this.transform.position = new Vector3(value.x, value.y, transform.position.z);
        }
    }
    public float x
    {
        get
        {
            return this.transform.position.x;
        }
        set
        {
            this.transform.position = new Vector3(value, this.transform.position.y, this.transform.position.z);
        }
    }
    public float y
    {
        get
        {
            return this.transform.position.y;
        }
        set
        {
            this.transform.position = new Vector3(this.transform.position.x, value, this.transform.position.z);
        }
    }

    public Vector2 velocity = new Vector2(0, 0);
    //public Vector2 speedCap = new Vector2(0.5f, 0.5f);
    [Range(0, 1)]
    public float roll = 0.7f;
    
    public float size = 1;
    public float halfSize
    {
        get
        {
            return size * 0.5f;
        }
    }
    public float bevel = 0.9f;
    public AABBCollider hitbox
    {
        get
        {
            return AABBCollider.MakeBoxCenter(x, y, size, size);
        }
    }
    public AABBCollider hitboxBevelX
    {
        get
        {
            return AABBCollider.MakeBoxCenter(x, y, size * bevel, size);
        }
    }
    public AABBCollider hitboxBevelY
    {
        get
        {
            return AABBCollider.MakeBoxCenter(x, y, size, size * bevel);
        }
    }

    public Vector2 spawnPoint = new Vector2();
    
    protected const int cStep = 4;

    // Use this for initialization
    public virtual void Start () {
	    if (GameObject.FindObjectOfType<LevelObject>())
        {
            levelDataRefrence = GameObject.FindObjectOfType<LevelObject>().GetComponent<LevelObject>();
        }
        GetComponent<SpriteRenderer>().sortingOrder = 1;
    }
	
	// Update is called once per frame
	public virtual void FixedUpdate () {
        /*if (velocity.x > speedCap.x)
        {
            velocity.x = speedCap.x;
        }
        if (velocity.x < -speedCap.x)
        {
            velocity.x = -speedCap.x;
        }
        if (velocity.y > speedCap.y)
        {
            velocity.y = speedCap.y;
        }
        if (velocity.y < -speedCap.y)
        {
            velocity.y = -speedCap.y;
        }*/
        
        velocity.x *= roll;
        velocity.y -= Globals.globals.gravity;
        if (velocity.y < -0.5f)
        {
            velocity.y = -0.5f;
        }

        if (velocity.x < 0.009f && velocity.x > -0.009f)
        {
            velocity.x = 0;
        }

        // Fall off screen
        if (y <= -size)
        {
            //TouchFloor(0, true);
            //TakeDamage();
            VoidOut();
        }

        // Move and Collide
        for (int i = 0; i < cStep; i++)
        {
            // move
            position += (velocity / cStep);
            // collide
            if (levelDataRefrence)
            {
                BlockCollision();
            }
        }
        
    }

    protected void BlockCollision()
    {
        foreach (BlockBase i in levelDataRefrence.blocks)
        {
            if (i.hitbox.Collision(hitboxBevelX) && i.active)
            {
                switch (i.FindNearestSide(position))
                {
                    case Side.Bottom:
                        if (velocity.y > 0)
                        {
                        i.TouchBottom(this);
                        }
                        break;

                    case Side.Top:
                        if (velocity.y < 0)
                        {
                            i.TouchTop(this);
                        }
                        break;
                    
                    default:
                        break;
                }
            }
            if (i.hitbox.Collision(hitboxBevelY) && i.active)
            {
                switch (i.FindNearestSide(position))
                {
                    case Side.Right:
                        if (velocity.x < 0)
                        {
                            i.TouchRight(this);
                        }
                        break;

                    case Side.Left:
                        if (velocity.x > 0)
                        {
                            i.TouchLeft(this);
                        }
                        break;

                    default:
                        break;
                }
            }
        }
    }

    public virtual void TouchFloor(float _y, bool _lands)
    {
        velocity.y = 0;
        y = _y + (size / 2);
    }
    public virtual void TouchCeiling(float _y)
    {
        velocity.y = 0;
        y = _y - (size / 2);
    }
    public virtual void TouchWallRight(float _x)
    {
        velocity.x = 0;
        x = _x - (size / 2);
    }
    public virtual void TouchWallLeft(float _x)
    {
        velocity.x = 0;
        x = _x + (size / 2);
    }

    public virtual void TakeDamage()
    {
        Respawn();
    }
    public virtual void VoidOut()
    {
        Respawn();
    }

    public void Respawn()
    {
        x = spawnPoint.x;
        y = spawnPoint.y;
        velocity = new Vector2(0, 0);
    }

    public float Diff(float one, float two)
    {
        return Mathf.Abs(one - two);
    }
}
