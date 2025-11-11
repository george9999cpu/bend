using UnityEngine;

public class FollowerEnemy : EnemyController
{
    public Transform target;   // drag the Player here in Inspector
    public float speed = 2f;   // how fast it follows

    void Update()
    {
        if (target == null) return;

        // move toward player
        Vector2 pos = transform.position;
        Vector2 targetPos = new Vector2(target.position.x, target.position.y);
        transform.position = Vector2.MoveTowards(pos, targetPos, speed * Time.deltaTime);

        // flip sprite toward player
        if (sr != null)
            sr.flipX = (target.position.x < transform.position.x);
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        // hurt the player on contact
        var ps = other.GetComponentInParent<PlayerStats>();
        if (ps != null)
            ps.TakeDamage(damage);
    }
}
