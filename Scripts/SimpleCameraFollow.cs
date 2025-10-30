using UnityEngine;

public class SimpleCameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 6, -10);

    void LateUpdate()
    {
        if (!target) return;
        // Using a matrix to compute camera position (optional demonstration of matrix use)
        Matrix4x4 m = Matrix4x4.TRS(target.position + offset, Quaternion.identity, Vector3.one);
        transform.position = m.GetColumn(3);
        transform.LookAt(target.position + Vector3.up * 1.0f);
    }
}
