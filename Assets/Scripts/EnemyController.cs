using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float walkSpeed = .5f; 
    Rigidbody2D myRigidbody;

    int direction = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            FlipSprite();
        }
    }

    void Walk() {
        Vector2 enemyVelocity = new Vector2(walkSpeed * direction, 0);
        myRigidbody.linearVelocity = enemyVelocity;
    }

    void FlipSprite()
    {
        direction = -direction;
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
}
