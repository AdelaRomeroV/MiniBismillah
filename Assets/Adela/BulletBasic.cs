using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBasic : MonoBehaviour
{
    [Header("Bullet")]
    private Rigidbody2D rb2D;
    public float speedB;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speedB * Time.fixedDeltaTime);
        Destroy(gameObject, 2f);
    }
}
