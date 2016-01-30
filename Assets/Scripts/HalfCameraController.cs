using UnityEngine;
using System.Collections;

public class HalfCameraController : MonoBehaviour {

	public Transform FollowPenis;
	private Camera thisCam;
	private Vector3 refSPeed;
	float smoothMove = 0.3f;
	float smoothRot = 0.3f;
	Vector3 cameraOffset = new Vector3(0, 0.22f, -0.22f);
	// Use this for initialization
	void Start () {
		thisCam = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
	//	transform.position = Vector3.SmoothDamp (transform.position, FollowPenis.position, ref refSPeed, smoothMove);
	//	transform.rotation = Quaternion.Slerp (transform.rotation, FollowPenis.rotation, smoothRot);
		transform.position = FollowPenis.position+cameraOffset;
		transform.rotation = FollowPenis.rotation;
	}
}
