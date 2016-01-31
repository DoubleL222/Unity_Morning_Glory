using UnityEngine;
using System.Collections;

public class Curek1 : MonoBehaviour
{
	public GameObject pissSpot;
	public GameObject pissSpotSmall	;

	public MissAudioPlayer MAP;

    public GameObject PissSystem;
	//public ParticleSystem PissSystemPS;
    public Vector3 offsetKapljic;
	private Vector3 rotatePiss = new Vector3(90.0f, 0, 0);

	public int SplatID;

	private Rigidbody rbd;

	void Start(){
		rbd = GetComponent<Rigidbody> ();
		//transform.forward = rbd.velocity;
		//transform.Rotate (rotatePiss);

	}
	void FixedUpdate(){
		transform.forward = rbd.velocity;
		transform.Rotate (rotatePiss);
	}

    void OnCollisionEnter(Collision c)
    {
        //if (c.gameObject.tag != "CurekLevi" && c.gameObject.tag != "CurekDesni")
        if (c.gameObject.tag != gameObject.tag)//če ni isti curek
        {
			if (c.gameObject.tag == "Room") {
				if (SplatID % 2 == 0) {
					GameObject tempSplat = Instantiate (pissSpot, c.contacts [0].point, Quaternion.identity) as GameObject;
					tempSplat.transform.forward = -c.contacts [0].normal;
					tempSplat.transform.RotateAround (transform.position, -c.contacts [0].normal, Random.Range (-360, 360));
					//Debug.Log(c.contacts[0].normal);
				}
			} else if (c.gameObject.tag == "RoomSmall") {
				if (SplatID % 2 == 0) {
					GameObject tempSplat = Instantiate (pissSpotSmall, c.contacts [0].point, Quaternion.identity) as GameObject;
					tempSplat.transform.forward = -c.contacts [0].normal;
					tempSplat.transform.RotateAround (transform.position, -c.contacts [0].normal, Random.Range (-360, 360));
				}
			} 
			if (c.gameObject.tag != "Water") {
				MAP.playSound ();
			}
		

			if (PissSystem!=null)
            {
              /*  for (int i = 0; i < 3; i++)
                {
                    Vector3 v = gameObject.transform.position + offsetKapljic;
                    GameObject g1 = (GameObject)Instantiate(kapljica, v, Quaternion.identity);
					addRandomForce(g1.GetComponent<Rigidbody>(), g1.transform);
                }*/
				PissSystem.transform.position = c.contacts [0].point;
				//GameObject pSystem = Instantiate (kapljica, c.contacts [0].point, Quaternion.LookRotation (c.contacts [0].normal)) as GameObject;
            }
			if (c.gameObject.tag != "RoomIgnore") {
				Destroy (gameObject);
			}
        }
    }
    
	void addRandomForce(Rigidbody rb, Transform kTransform)
    {
        Vector3 random = new Vector3(Random.Range(-1f, 1f), Random.Range(0f, 2f), Random.Range(-1f, 1f));
		float randomS = Random.Range (0.01f, 0.05f);
		Vector3 randomScale = new Vector3 (randomS, randomS, randomS);
        rb.AddForce(random * 30);
		kTransform.localScale = randomScale;
    }
}
