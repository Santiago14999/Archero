using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform Target;
    public float OffsetZ;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, Target.position.z + OffsetZ);
    }
}
