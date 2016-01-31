using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour
{
    Vector3 speed = new Vector3(0, 0.4f, 0);
    //void Start()
    //{
    //    this.offset = this.viewArea.height;
    //}

    void Update()
    {
        gameObject.transform.position += speed;

        if (gameObject.transform.position.y > 600)
            Debug.Log("Konec"); //namesto tega greš nazaj na main menu
    }
}
