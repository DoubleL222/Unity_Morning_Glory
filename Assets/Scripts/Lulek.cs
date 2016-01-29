using UnityEngine;
using System.Collections;

public class Lulek : MonoBehaviour
{
    public enum smer
    { Naprej, Levo, Desno, Nazaj }

    public smer smerCurka = smer.Naprej;
    public GameObject curek;
    [Range(0,300)]
    public float moč = 200f;

	//void Start ()
    //{
	
	//}
	

	void Update ()
    {
	    
	}

	public void SpawnPiss(){
		if (curek != null)
		{
			GameObject temp = (GameObject)Instantiate(curek, gameObject.transform.position, Quaternion.identity);
			addForce(temp.GetComponent<Rigidbody>());
		}
	}

    void addForce(Rigidbody rb)
    {
        switch (smerCurka)
        {
            case smer.Naprej:
                rb.AddForce(transform.forward * moč);
                break;
            case smer.Nazaj:
                rb.AddForce(-transform.forward * moč);
                break;
            case smer.Levo:
                rb.AddForce(transform.right * moč);
                break;
            case smer.Desno:
                rb.AddForce(-transform.right * moč);
                break;
        }
         
    
    }
}
