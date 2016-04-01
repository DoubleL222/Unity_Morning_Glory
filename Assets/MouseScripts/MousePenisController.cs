using UnityEngine;
using System.Collections;

public class MousePenisController : MonoBehaviour {
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	public float minimumX = -360F;
	public float maximumX = 360F;
	public float minimumY = -60F;
	public float maximumY = 60F;
	float rotationY = 0F;

	public Lulek lulekController;
	public Scoring scoringScript;

    private float screenWidth;
    private float screenHeight;
    private static float MaxPenisOffsetX = 5.0f;
    private static float MaxPenisOffsetY = 5.0f;
    // Use this for initialization
    void Start () {
		UpdateScreenLuka ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (axes == RotationAxes.MouseXAndY)
		{
			float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

			transform.localEulerAngles = new Vector3(rotationY, rotationX, 0);
		}
		else if (axes == RotationAxes.MouseX)
		{
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
		}
		else
		{
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

			transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
		}

		if (Input.GetMouseButton (0)) {
			if (scoringScript.amountOfScanjePly1 > 0) {
				lulekController.SpawnPiss (1);
				lulekController.ActivatePissSystem (true);
				scoringScript.PlayerAmountDecrease (1);
				scoringScript.PlayerAmountDecrease (2);
			} else {
				lulekController.playFinishSound ();
			}
		} else {
			lulekController.ActivatePissSystem (false);
		}
	}

    void UpdateScreenLuka()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }
    float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
