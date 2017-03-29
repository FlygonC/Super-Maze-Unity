using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Worlds : int
{
    TrapFactory,
    CloudySky,
    SpookyHouse,
    PuzzleTower,

    HazardMayhem,
    ThunderStorm,

    PuzzleDungeon,

    StarDust,
}

public class Globals : MonoBehaviour {

    public static Globals globals;

    public float gravity;
    //public float windDrag;
    public float timescaler = 1;

    public List<LevelObject> Levels_TF = new List<LevelObject>();
    public Sprite TrapFactoryBG;
    public List<LevelObject> Levels_CS = new List<LevelObject>();
    public Sprite CloudySkyBG;
    public List<LevelObject> Levels_SH = new List<LevelObject>();
    public Sprite SpookyBG;

    public Dictionary<Worlds, List<LevelObject>> Levels
    {
        get
        {
            Dictionary<Worlds, List<LevelObject>> final = new Dictionary<Worlds, List<LevelObject>>();

            final.Add(Worlds.TrapFactory, Levels_TF);
            final.Add(Worlds.CloudySky, Levels_CS);
            final.Add(Worlds.SpookyHouse, Levels_SH);

            return final;
        }
    }

	// Use this for initialization
	void Start () {
	    if (globals != gameObject)
        {
            DontDestroyOnLoad(this);
            globals = this;
        }
        else if (globals != this)
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        Time.timeScale = timescaler;
	}

    public static LevelObject GetLevel(Worlds _world, int _level)
    {
        if (_level < 0 || _level >= 5)
        {
            return globals.Levels_TF[0];
        }
        else
        {
            return globals.Levels[_world][_level];
        }
    }
    
}
