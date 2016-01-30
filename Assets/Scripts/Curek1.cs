using UnityEngine;
using System.Collections;

public class Curek1 : MonoBehaviour
{
    public GameObject kapljica;

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag != gameObject.tag)//če ni isti curek
        {
            if (kapljica != null)
            {
                    Instantiate(kapljica, gameObject.transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }

    ////Katastrofa
    //void addRandomForce(Rigidbody rb)
    //{
    //    Vector3 random = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
    //    rb.AddForce(random * 30);    
    //}
}
