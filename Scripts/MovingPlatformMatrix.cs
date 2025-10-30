using UnityEngine;

public class MovingPlatformMatrix : MonoBehaviour
{
    public Vector3 center = new Vector3(0, 5, 0);
    public float radius = 4f;
    public float angularSpeed = 30f; // degrees per second
    public Vector3 scaleOscillation = new Vector3(0.2f, 0, 0); // small scale change

    float angle = 0;

    void Update()
    {
        // angle increment
        angle += angularSpeed * Time.deltaTime;
        float rad = angle * Mathf.Deg2Rad;

        // calculate position using matrix TRS
        Vector3 pos = center + new Vector3(Mathf.Cos(rad) * radius, 0, Mathf.Sin(rad) * radius);

        // scale oscillation using sine of angle
        float s = 1 + Mathf.Sin(rad) * scaleOscillation.x;

        Matrix4x4 m = Matrix4x4.TRS(pos, Quaternion.Euler(0, angle, 0), new Vector3(s, 1, s));
        // apply matrix to transform
        transform.position = m.GetColumn(3);
        transform.rotation = Quaternion.LookRotation(m.GetColumn(2), m.GetColumn(1));
        transform.localScale = new Vector3(s, 0.5f, s);
    }
}
