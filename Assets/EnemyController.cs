using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float maxSpeed = 2f;   // how fast it moves
    public int damage = 1;        // damage to the player
    public SpriteRenderer sr;     // for flipping left/right

    protected int dir = -1;       // -1 means left, 1 means right

    protected virtual void Start()
    {
        if (!sr) sr = GetComponent<SpriteRenderer>();
    }

    // Flip direction when hitting a wall or another enemy
    public virtual void Flip()
    {
        dir *= -1;
        if (sr) sr.flipX = !sr.flipX;
    }

    // What happens when this enemy hits something
    protected virtual void OnTriggerEnter2D(Collider2D other)
{
    // Check if what we hit has a PlayerStats component (even if it's on the parent)
    PlayerStats ps = other.GetComponentInParent<PlayerStats>();
    if (ps != null)
    {
        ps.TakeDamage(damage);
        Flip();
        return;
    }

    // Flip on walls or other enemies
    if (other.CompareTag("Wall") || other.CompareTag("Enemy"))
    {
        Flip();
    }
}
}
