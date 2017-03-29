using UnityEngine;
using System.Collections;

public class FlameThrow : Actor {

    public int lifeTime = 180;
    public float speed = 0.05f;

    [SerializeField]
    private PlayerControl player;

    public override void Start()
    {
        base.Start();
        size = 0.8f;

        player = FindObjectOfType<PlayerControl>();
    }

    public override void FixedUpdate()
    {
        if (player != null)
        {
            //PlayerControl player = FindObjectOfType<PlayerControl>();

            velocity = (player.position - position).normalized * speed;
            position += velocity;
            if (levelDataRefrence)
            {
                BlockCollision();
            }

            lifeTime--;
            if (lifeTime <= 0)
            {
                Destroy(gameObject);
            }

            if (hitbox.Collision(player.hitbox))
            {
                player.TakeDamageSoft();
                Destroy(gameObject);
            }
        }
            //base.FixedUpdate();
        }

    public override void TakeDamage()
    {
        //base.TakeDamage();
    }
}
