using UnityEngine;
using System.Collections;

public class Curek1 : MonoBehaviour
{
	
    public GameObject kapljica;
    public Vector3 offsetKapljic;
	private Vector3 rotatePiss = new Vector3(90.0f, 0, 0);

	private Rigidbody rbd;

	void Start(){
		rbd = GetComponent<Rigidbody> ();
		transform.forward = rbd.velocity;
		transform.Rotate (rotatePiss);

	}
	void FixedUpdate(){
		transform.forward = rbd.velocity;
		transform.Rotate (rotatePiss);
	}

    void OnCollisionEnter(Collision c)
    {
		if (c.gameObject.tag != gameObject.tag)//če ni isti curek
        {
			if (kapljica != null && c.gameObject.tag != "Water")
            {
                for (int i = 0; i < 3; i++)
                {
                    Vector3 v = gameObject.transform.position + offsetKapljic;
                    GameObject g1 = (GameObject)Instantiate(kapljica, v, Quaternion.identity);
					addRandomForce(g1.GetComponent<Rigidbody>(), g1.transform);
                }
            }

            Destroy(gameObject);
        }
    }
    
	void addRandomForce(Rigidbody rb, Transform kTransform)
    {
		
        Vector3 random = new Vector3(Random.Range(-1f, 1f), Random.Range(0f, 2f), Random.Range(-1f, 1f));
        //rb.AddForce(random * 30);
        rb.velocity = random;
    }
}
