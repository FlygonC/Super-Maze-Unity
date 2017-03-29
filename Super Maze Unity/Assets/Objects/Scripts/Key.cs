using UnityEngine;
using System.Collections;

public class Key : Pickupable
{
    [SerializeField]
    private DeathShard shard;
    [SerializeField]
    private DeathShard shardTwo;

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
