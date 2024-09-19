using UnityEngine;

public class BouncyBall : MonoBehaviour
{
    public float bounceForce = 3F;

	private void OnCollisionEnter(Collision collision)
	{
		GetComponent<Rigidbody>().AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
	}
}






