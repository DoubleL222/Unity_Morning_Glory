using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour
{
    public RectTransform rTransform;
    Vector3 speed;
    void Start()
    {
        speed = new Vector3(0, Screen.height/300f, 0);
    }

    void Update()
    {
        if (rTransform.position.y < Screen.height - 30)
        {
            rTransform.position += speed;
            //Debug.Log("Majnše  " + rTransform.position);
        }
    }
}
