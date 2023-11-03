using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class shooter : MonoBehaviour
{
    [Header("Movimiento")]
    private Rigidbody2D rb2D;
    private Vector2 playerInput;
    public float moveSpeed;

    [Header("Disparo")]
    public Transform shotPoint;
    public GameObject bullet;
    public float timeShots;
    private float nextShoop;

    [Header("Contador")]
    public float souls;
    public float life;

    [Header("Rotacion")]
    public Transform weapon;
    private float offset = 90f;

    // Start is called before the first frame update
    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rotShoter();
        Mov();
        Rot();
    }

    private void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + playerInput * moveSpeed * Time.deltaTime);
    }

    void rotShoter()//rotacion del arma y disparo
    {

        if (Input.GetMouseButton(0))
        {
            if (Time.time > nextShoop)
            {
                nextShoop = Time.time + timeShots;
                Instantiate(bullet, shotPoint.position, shotPoint.rotation);
            }
        }
    }

    void Rot()
    {
        Vector3 displacement = weapon.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float playerInput = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        weapon.rotation = Quaternion.Euler(0f, 0f, playerInput + offset);
    }

    void Mov()
    {
        //Movimiento
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        playerInput = new Vector2(moveX, moveY).normalized;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Items"))
        {
            Destroy(collision.gameObject);

            souls += collision.gameObject.GetComponent<Items>().soulsMax;

        }
    }
    

}
