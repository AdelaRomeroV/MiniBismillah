using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody2D rb2D;

    [SerializeField]
    private Vector2 direction;

    public int fuerza;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3);
    }

    private void Update()
    {
        Move();
    }

    public void GetDirection(Vector2 dirction)
    {
        direction = dirction;
    }

    private void Move()
    {
        rb2D.velocity = direction.normalized * speed;
    }
}
