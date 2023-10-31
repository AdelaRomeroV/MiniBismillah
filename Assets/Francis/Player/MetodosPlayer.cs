using UnityEngine;

public class MetodosPlayer : MonoBehaviour
{
    [Header("Ulti")]
    [SerializeField] private GameObject bulletPrefab;
    private Vector2 direction;

    private void Update()
    {
        Ulti();
    }

    public void Regeneracion()
    {

    }

    public void Ulti()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.transform.position = transform.position;
            obj.gameObject.GetComponent<Bullet>().GetDirection(direction);
        }
    }
}
