using UnityEngine;
using System.Collections;

public class Curek1 : MonoBehaviour
{
    public GameObject kapljica;
    public Vector3 offsetKapljic;

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag != gameObject.tag)//če ni isti curek
        {
            if (kapljica != null)
            {
                for (int i = 0; i < 3; i++)
                {
                    Vector3 v = gameObject.transform.position + offsetKapljic;
                    GameObject g1 = (GameObject)Instantiate(kapljica, v, Quaternion.identity);
                    addRandomForce(g1.GetComponent<Rigidbody>());
                }
            }

            Destroy(gameObject);
        }
    }
    
    void addRandomForce(Rigidbody rb)
    {
        Vector3 random = new Vector3(Random.Range(-1f, 1f), Random.Range(0f, 2f), Random.Range(-1f, 1f));
        //rb.AddForce(random * 30);
        rb.velocity = random;
    }
}
