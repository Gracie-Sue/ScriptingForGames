using UnityEngine;

public class TransformController : MonoBehaviour
{
    private void Update()
    {
        // Move the target GameObject
        var x = Mathf.PingPong(Time.time, 3);
        var z = Mathf.PingPong(Time.time, 3);
        var p = new Vector3(x, 0, z);
        transform.position = p;
        
        // Rotate the target GameObject
        transform.Rotate(new Vector3(30, 60, 0) * Time.deltaTime);
    }
}
