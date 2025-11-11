using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WalkingEnemy : EnemyController
{
    Rigidbody2D rb;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;   // no falling
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        // move left or right continuously
        rb.velocity = new Vector2(dir * maxSpeed, rb.velocity.y);
    }
}
