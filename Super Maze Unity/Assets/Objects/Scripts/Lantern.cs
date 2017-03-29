using UnityEngine;
using System.Collections;

public class Lantern : Pickupable
{

    public float radius = 5;

    [SerializeField]
    private DeathShard shard;
    [SerializeField]
    private DeathShard shardTwo;
    [SerializeField]
    private SpriteRenderer glow;

    public override void Start()
    {
        base.Start();
        float newScale = radius - (0.5f);
        glow.transform.localScale = new Vector3(newScale, newScale, 1);
    }

    public override void TakeDamage()
    {
        for (int i = 0; i < 4; i++)
        {
            DeathShard newshard = (DeathShard)Instantiate(shard, transform.position, transform.rotation);
            newshard.selfKill = Random.Range(5, 90);
            DeathShard newshardTwo = (DeathShard)Instantiate(shardTwo, transform.position, transform.rotation);
            newshardTwo.selfKill = Random.Range(5, 90);
        }
        Respawn();
        base.TakeDamage();
    }
}
