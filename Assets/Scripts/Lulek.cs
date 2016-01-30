using UnityEngine;
using System.Collections;

public class Lulek : MonoBehaviour
{
    public enum smer
    { Naprej, Levo, Desno, Nazaj }

    public smer smerCurka = smer.Naprej;
    public GameObject curek;
	private float moc = 150f;

	//void Start ()
    //{
	
	//}
	

	void Update ()
    {
        
	}

	public void SpawnPiss(Quaternion pissRot, float PissForce){
		if (curek != null)
		{
			
			GameObject temp = (GameObject)Instantiate(curek, gameObject.transform.position, pissRot*Quaternion.Euler(new Vector3(90.0f, 0f, 0f)));
			Rigidbody CurekRBD = temp.GetComponent<Rigidbody> ();
			CurekRBD.AddForce(transform.forward * PissForce * moc);
			temp.transform.forward = CurekRBD.velocity;
			temp.transform.Rotate (new Vector3(90.0f, 0, 0));
			//addForce(temp.GetComponent<Rigidbody>());
			/*temp = (GameObject)Instantiate(curek, gameObject.transform.position, Quaternion.identity);
			addForce(temp.GetComponent<Rigidbody>());
			temp = (GameObject)Instantiate(curek, gameObject.transform.position, Quaternion.identity);
			addForce(temp.GetComponent<Rigidbody>());*/
		}
	}

    void addForce(Rigidbody rb)
    {
        switch (smerCurka)
        {
            case smer.Naprej:
                rb.AddForce(transform.forward * moc);
                break;
            case smer.Nazaj:
                rb.AddForce(-transform.forward * moc);
                break;
            case smer.Levo:
                rb.AddForce(transform.right * moc);
                break;
            case smer.Desno:
                rb.AddForce(-transform.right * moc);
                break;
        }
    }
}
