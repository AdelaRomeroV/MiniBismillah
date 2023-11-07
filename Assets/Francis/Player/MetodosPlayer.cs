using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class MetodosPlayer : MonoBehaviour
{
    [Header("Ulti")]
    [SerializeField] private GameObject bulletPrefab;
    private Vector2 direction;

    public int points = 50;

    public int life = 5;
    private int lifemax = 0;

    private void Awake()
    {
        direction = Vector2.up;
        lifemax = life;
    }

    private void Update()
    {
        SetDirection();
        Ulti();
        Regeneracion();
    }

    public void Regeneracion()
    {
        if(Input.GetKeyDown(KeyCode.Q) && points >= 5 && !(life >= lifemax))
        {
            ChangeLife(2);
            points--;
        }
    }

    public void ChangeLife(int value)
    {
        life += value;
        if(life <= 0)
        {
            Destroy(gameObject);
        }
        if (life >= lifemax) 
        {
            life = lifemax;
        }
    }

    public void SetDirection()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            direction = new Vector2(horizontal, vertical);
        }
    }

    public void Ulti()
    {
        if (Input.GetKeyDown(KeyCode.E) && points >= 1)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.transform.position = transform.position;
            obj.gameObject.GetComponent<Bullet>().GetDirection(direction);
        }
    }
}
