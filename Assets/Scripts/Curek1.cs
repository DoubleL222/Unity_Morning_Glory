using UnityEngine;
using System.Collections;

public class Curek1 : MonoBehaviour
{
    public GameObject kapljica;

    void OnCollisionEnter(Collision c)
    {
        //Debug.Log(c.contacts[0].point);
        //Debug.Log(c.contacts.Length);
        if (c.gameObject.tag != gameObject.tag)//če ni isti curek
        {
            if (kapljica != null)
            {
                for (int i = 0; i < 2; i++)
                {
                    GameObject temp = (GameObject)Instantiate(kapljica, gameObject.transform.position, Quaternion.identity);
                    addRandomForce(temp.GetComponent<Rigidbody>());
                }
            }

            Destroy(gameObject);
        }
    }

    void addRandomForce(Rigidbody rb)
    {
        Vector3 random = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
        rb.AddForce(random * 30);
                
    }
}
