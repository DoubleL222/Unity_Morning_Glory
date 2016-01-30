using UnityEngine;
using System.Collections;

public class KapljicaController : MonoBehaviour {

	// Use this for initialization
	void OnCollisionEnter(Collision c){
		Destroy (gameObject);
	}
}
