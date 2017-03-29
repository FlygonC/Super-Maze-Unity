using UnityEngine;
using System.Collections;

public class Ghost_Black : BlockBase
{

    [SerializeField]
    private Lantern[] lanterns;
    [SerializeField]
    private SpriteRenderer sprite;

    public Sprite onSprite;
    public Sprite offSprite;

    private bool inLight
    {
        get
        {
            foreach (Lantern i in lanterns)
            {
                if (((i.position - new Vector2(0.5f, 0.5f)) - (Vector2)transform.position).magnitude < i.radius)
                {
                    return true;
                }
            }
            return false;
        }
    }

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        lanterns = FindObjectsOfType<Lantern>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (inLight)
        {
            active = false;
            sprite.sprite = offSprite;
        }
        else
        {
            active = true;
            sprite.sprite = onSprite;
        }
    }
}