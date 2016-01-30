using UnityEngine;
using System.Collections;

public class KapljiceEffect : MonoBehaviour
{
    float timer = 0;
    float casTrajanja = 1;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= casTrajanja)
            Destroy(gameObject);
    }

    
}
