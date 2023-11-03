using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Explocion : MonoBehaviour
{
    [Header("Ataque")]
    public float chekRaius;
    public float attackRadius;
    private float timer = 0;

    public LayerMask whatIsPlayer;
    private shooter Player;

    [Header("animacion de detecion")]
    public SpriteRenderer spriteRen;
    public float cambioColor;
    public GameObject fxExplosion;
   
    private void awake()
    {
        Player = GameObject.FindWithTag("lifeplayer").GetComponent<shooter>();
    }

    // Update is called once per frame
    void Update()
    {
        Explo();
        
    }

    public void Explo()
    {
        if(detection() == true)
        {
            timer -= Time.deltaTime;
            StartCoroutine(CambioColor());

            if (timer <= 0)
            {
                Instantiate(fxExplosion, transform.position, transform.rotation);
                Destroy(gameObject);
            }

            else
            {
                StopAllCoroutines();
                timer = 1.6f;
                spriteRen.material.SetColor("_Color", Color.red);
            }

        }
    }

    private bool detection() //detecta al enemigo
    {
        return Physics2D.OverlapCircle(transform.position, chekRaius, whatIsPlayer);
    }

    private IEnumerator CambioColor()
    {
        while(true) 
        {
            spriteRen.material.SetColor("_Color", Color.white);
            yield return new WaitForSeconds(cambioColor);

            spriteRen.material.SetColor("_Color", Color.red);
            yield return new WaitForSeconds(cambioColor);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chekRaius);
    }
}
