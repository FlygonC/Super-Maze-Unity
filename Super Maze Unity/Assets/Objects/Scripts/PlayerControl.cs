using UnityEngine;
using System.Collections;

public class PlayerControl : Actor {
    
    public float moveSpeed = 0.01f;
    public float jumpStrength = 0.44f;

    public float acceleration = 0;
    public float maxSpeed = 5.5f / 60.0f;
    public bool right = true;

    public int life = 4;
    private int staticIFrames = 0;

    public bool canjump = true;

    [SerializeField]
    private Pickupable holding = null;
    public Pickupable heldItem
    {
        get
        {
            return holding;
        }
    }
    public bool isHolding
    {
        get
        {
            return holding != null;
        }
    }

    [SerializeField]
    private DeathShard shardBlue;
    [SerializeField]
    private DeathShard shardRed;
    [SerializeField]
    private DeathShard shardGreen;

    public bool touchingGate = false;

    public override void FixedUpdate()
    {
        bool buttonPressed = false;

        if (Input.GetButton("Right"))
        {
            if (acceleration <= 0)
            {
                right = true;
            }
            if (right)
            {
                acceleration += moveSpeed;
                buttonPressed = true;
            }
            else
            {
                acceleration -= moveSpeed;
            }
        }
        if (Input.GetButton("Left"))
        {
            if (acceleration <= 0)
            {
                right = false;
            }
            if (!right)
            {
                acceleration += moveSpeed;
                buttonPressed = true;
            }
            else
            {
                acceleration -= moveSpeed;
            }
        }

        if (acceleration > maxSpeed)
        {
            acceleration = maxSpeed;
        }
        if (right)
        {
            velocity.x += acceleration;
        } else
        {
            velocity.x -= acceleration;
        }
        
        if (acceleration > 0 && !buttonPressed)
        {
            acceleration *= 0.7f;
            if (acceleration <= 0.009f)
            {
                acceleration = 0;
            }
        }
        /*if (acceleration < 0.009f && acceleration > -0.009f)
        {
            acceleration = 0;
        }*/

        if (Input.GetButton("Jump"))
        {
            if (canjump)
            {
                velocity.y = jumpStrength;
                canjump = false;
            }
        }

        if (staticIFrames > 0)
        {
            staticIFrames -= 1;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        /*if (canjump)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.8f, 0.8f, 1);
        }*/

        base.FixedUpdate();
    }

    // Update is called once per frame
    void Update () {
        //base.FixedUpdate();
        
        if (holding != null)
        {
            holding.position = position + new Vector2(0, 0.7f);
            holding.velocity = new Vector2(0, 0);
        }
        if (Input.GetButtonDown("Pickup") && !touchingGate)
        {
            Pickup();
        }
        touchingGate = false;
        
	}

    void Pickup()
    {
        if (holding == null)
        {
            foreach (Pickupable i in FindObjectsOfType<Pickupable>())
            {
                if (i.hitbox.Collision(hitbox))
                {
                    holding = i;
                    break;
                }
            }
            return;
        }
        else
        {
            DropItem();
            return;
        }
    }
    public void DropItem()
    {
        if (holding != null)
        {
            holding.position = position;
            holding.velocity.x = (velocity.x * 1.2f);
            holding.velocity.y = Mathf.Min( velocity.y + 0.25f, 0.5f );
            holding = null;
        }
    }

    void Die()
    {
        Destroy(gameObject);
        for (int i = 0; i < 15; i++)
        {
            Instantiate(shardBlue, transform.position, transform.rotation);
            Instantiate(shardRed, transform.position, transform.rotation);
            Instantiate(shardGreen, transform.position, transform.rotation);
        }
        life = 0;
    }

    public override void TouchFloor(float _y, bool _lands)
    {
        base.TouchFloor(_y, _lands);
        if (_lands)
        {
            canjump = true;
        }
    }

    public override void TakeDamage()
    {
        if (staticIFrames <= 0)
        {
            DropItem();
            life -= 1;
            if (life <= 0)
            {
                Die();
            }
            staticIFrames = 60 * 3;
            //base.TakeDamage();
        }
    }
    public void TakeDamageSoft()
    {
        DropItem();
        life -= 1;
        if (life <= 0)
        {
            Die();
        }
    }

    public override void VoidOut()
    {
        Die();
    }
}
