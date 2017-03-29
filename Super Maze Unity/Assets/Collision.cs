using UnityEngine;
using System.Collections;

[System.Serializable]
public class AABBCollider
{
    public float x1 = 0;
    public float x2 = 0;
    public float y1 = 0;
    public float y2 = 0;

    /*public Vector2 BoxCenter
    {
        get
        {
            return new Vector2((x1 - x2) / 2, (y1 - y2) / 2);
        }
    }*/

    public bool CollisionX(AABBCollider other)
    {
        return other.x2 > x1 && other.x1 < x2;
    }
    public bool CollisionY(AABBCollider other)
    {
        return other.y2 > y1 && other.y1 < y2;
    }
    public bool Collision(AABBCollider other)
    {
        return CollisionX(other) && CollisionY(other);
    }

    public static AABBCollider MakeBoxCenter(float _x, float _y, float _width, float _height)
    {
        AABBCollider box = new AABBCollider();
        box.x1 = _x - _width / 2;
        box.x2 = _x + _width / 2;
        box.y1 = _y - _height / 2;
        box.y2 = _y + _height / 2;

        return box;
    }
    public static AABBCollider MakeBoxBLCorner(float _x, float _y, float _width, float _height)
    {
        AABBCollider box = new AABBCollider();
        box.x1 = _x;
        box.x2 = _x + _width;
        box.y1 = _y;
        box.y2 = _y + _height;

        return box;
    }
    public static AABBCollider MakeBoxTLCorner(float _x, float _y, float _width, float _height)
    {
        AABBCollider box = new AABBCollider();
        box.x1 = _x;
        box.x2 = _x + _width;
        box.y1 = _y - _height;
        box.y2 = _y;

        return box;
    }
    
}