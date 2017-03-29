using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

//[ExecuteInEditMode]
public class LevelObject : MonoBehaviour
{
    
    public string levelName;
    //public BlockBase prefab;
    public List<BlockBase> blocks = new List<BlockBase>();

    public bool triState = true;
    public int maxGems = 0;
    public int collectedGems = 0;
    public bool gemState
    {
        get
        {
            return collectedGems == maxGems;
        }
    }

    void Start () {
        /*for (int y = 0; y < levelHeight; y++)
        {
            for (int x = 0; x < levelWidth; x++)
            {
                Block newBlock = (Block)Instantiate(prefab);
                newBlock.x = x;
                newBlock.y = y;
                newBlock.transform.parent = this.transform;
            }
        }*/
        blocks = FindObjectsOfType<BlockBase>().ToList();
        triState = true;

        Actor player = FindObjectOfType<PlayerControl>().GetComponent<Actor>();
        //player.x = FindObjectOfType<PlayerStart>().transform.position.x;
        //player.y = FindObjectOfType<PlayerStart>().transform.position.y;
        player.spawnPoint = FindObjectOfType<PlayerStart>().transform.position;
        player.Respawn();
        FindObjectOfType<Camera>().transform.position = new Vector3(player.position.x, player.position.y, -10);
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
