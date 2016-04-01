using UnityEngine;
using System.Collections;

public class Lulek : MonoBehaviour
{
    public enum smer
    { Naprej, Levo, Desno, Nazaj }

    public smer smerCurka = smer.Naprej;
    public GameObject curek;
	private float moc = 150f;
	public GameObject PissSystem;

	private MissAudioPlayer MAP;

	private ParticleSystem PSPS;

	private AudioSource thisAudioSource;
	private int SplatID =0;

	void Start ()
    {
		thisAudioSource = gameObject.GetComponent<AudioSource> () as AudioSource;
		MAP = Object.FindObjectOfType<MissAudioPlayer> () as MissAudioPlayer;
		PSPS = PissSystem.GetComponent<ParticleSystem> () as ParticleSystem;
	}

	public void playFinishSound(){
		if (!thisAudioSource.isPlaying) {
			thisAudioSource.Play ();
		}
	}

	public void ActivatePissSystem(bool activate){
		PSPS.enableEmission = activate;
	}

	void Update ()
    {
        
	}

	public void SpawnPiss(float PissForce){
		if (curek != null)
		{
			//*Quaternion.Euler(new Vector3(90.0f, 0f, 0f))
			GameObject temp = (GameObject)Instantiate(curek, gameObject.transform.position, Quaternion.LookRotation(transform.up)*Quaternion.Euler(new Vector3(90.0f, 0f, 0f)));
			Curek1 curekScript = temp.GetComponent<Curek1> ();
			curekScript.PissSystem = PissSystem;
			curekScript.SplatID = SplatID;
			curekScript.MAP = MAP;
			SplatID++;
			Rigidbody CurekRBD = temp.GetComponent<Rigidbody> ();
			CurekRBD.AddForce(transform.up * PissForce * moc);
			//temp.transform.forward = CurekRBD.velocity;
			//temp.transform.Rotate (new Vector3(90.0f, 0, 0));
			//addForce(temp.GetComponent<Rigidbody>());
			/*temp = (GameObject)Instantiate(curek, gameObject.transform.position, Quaternion.identity);
			addForce(temp.GetComponent<Rigidbody>());
			temp = (GameObject)Instantiate(curek, gameObject.transform.position, Quaternion.identity);
			addForce(temp.GetComponent<Rigidbody>());*/
		}
	}
}
