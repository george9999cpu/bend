using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health = 3;
    public int lives  = 3;

    // flicker while immune
    float flickerT = 0f;
    public float flickerDur = 0.1f;

    SpriteRenderer sr;

    // immunity window
    public bool isImmune = false;
    float immuneT = 0f;
    public float immuneDur = 1.5f;

    void Start() { sr = GetComponent<SpriteRenderer>(); }

    public void TakeDamage(int dmg)
    {
        if (isImmune) return;

        health -= dmg;
        if (health <= 0)
        {
            health = 0;
            if (lives > 0)
            {
                // your LevelManager from earlier labs
                FindObjectOfType<levelmanager>()?.RespawnPlayer();
                health = 3;
                lives--;
            }
            else
            {
                Debug.Log("Game Over");
                Destroy(gameObject);
                return;
            }
        }

        isImmune = true;
        immuneT = 0f;
    }

    void Update()
    {
        if (!isImmune) return;

        SpriteFlicker();
        immuneT += Time.deltaTime;
        if (immuneT >= immuneDur)
        {
            isImmune = false;
            sr.enabled = true; // end flicker
        }
    }

    void SpriteFlicker()
    {
        flickerT += Time.deltaTime;
        if (flickerT >= flickerDur)
        {
            sr.enabled = !sr.enabled;
            flickerT = 0f;
        }
    }
}
