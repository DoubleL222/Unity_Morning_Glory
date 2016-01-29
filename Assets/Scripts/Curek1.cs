using UnityEngine;
using System.Collections;

public class Curek1 : MonoBehaviour
{
    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag != "Curek")
            Destroy(gameObject);
    }
}
