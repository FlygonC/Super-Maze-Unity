﻿using UnityEngine;
using System.Collections;

public class TriBlock_Green : BlockBase {

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
        if (level.triState == false)
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
