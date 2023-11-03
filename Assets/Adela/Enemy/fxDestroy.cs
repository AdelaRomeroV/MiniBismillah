using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fxDestroy : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 0.25f);
    }
}
