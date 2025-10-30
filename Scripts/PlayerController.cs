using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 12f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public LayerMask groundLayer;

    [Header("UI (Optional)")]
    public TextMeshProUGUI positionText;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Prevents tipping over
    }

    void Update()
    {
        // 🔹 Ground check (small sphere under player)
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.3f, groundLayer);

        // 🔹 Movement input
        float moveX = Input.GetAxis("Horizontal"); // A / D
        float moveZ = Input.GetAxis("Vertical");   // W / S

        Vector3 move = new Vector3(moveX, 0, moveZ) * moveSpeed;
        Vector3 newVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);
        rb.linearVelocity = newVelocity;

        // 🔹 Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
        }

        // 🔹 Optional: show player position
        if (positionText != null)
            positionText.text = $"Position: {transform.position:F2}";
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(groundCheck.position, 0.3f);
        }
    }
}
