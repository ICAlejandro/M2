using UnityEngine;
using TMPro;
using UnityEngine.InputSystem; // New Input System

public class EnemyBackstab : MonoBehaviour
{
    public float backstabRange = 2f;
    [Range(-1f, 1f)]
    public float backstabDotThreshold = -0.6f;
    public TextMeshProUGUI feedbackText;
    public Transform enemyForwardSource;

    void Start()
    {
        if (enemyForwardSource == null) enemyForwardSource = transform;
    }

    void Update()
    {
        // Press E (new Input System)
        if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player == null) return;

            Vector3 toPlayer = player.transform.position - transform.position;
            float dist = toPlayer.magnitude;
            if (dist > backstabRange)
            {
                if (feedbackText) feedbackText.text = "Too far to attack";
                return;
            }

            Vector3 dirToPlayer = toPlayer.normalized;
            Vector3 enemyForward = enemyForwardSource.forward.normalized;
            float dot = Vector3.Dot(enemyForward, dirToPlayer);

            if (dot < backstabDotThreshold)
            {
                if (feedbackText) feedbackText.text = "Backstab Successful";
                Destroy(gameObject, 0.25f);
            }
            else
            {
                if (feedbackText) feedbackText.text = "Attack Failed";
            }
        }
    }
}
