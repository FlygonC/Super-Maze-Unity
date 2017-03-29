using UnityEngine;
using System.Collections;

public class GemBlock_Blue : BlockBase
{

    [SerializeField]
    private LevelObject level;
    [SerializeField]
    private SpriteRenderer sprite;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        level = FindObjectOfType<LevelObject>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (level.gemState == true)
        {
            active = true;
            sprite.color = new Color(1, 1, 1, 1);
        }
        else
        {
            active = false;
            sprite.color = new Color(1, 1, 1, 0.25f);
        }
    }
}