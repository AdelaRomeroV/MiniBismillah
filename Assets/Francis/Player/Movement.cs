using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Rigidbody2D rb2D;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rb2D.velocity = new Vector2(horizontal, vertical) * speed;
    }
}
