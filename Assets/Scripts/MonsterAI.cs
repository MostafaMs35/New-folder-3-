using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MonsterAI : MonoBehaviour
{
    public float moveSpeed = 2.4f;

    private Transform player;
    private CharacterController characterController;

    private bool isEnabled = false;
    private bool isChasing = false;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        GameObject playerObject =
            GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
            player = playerObject.transform;
    }

    public void EnableMonster()
    {
        isEnabled = true;
        isChasing = true;
    }

    public void DisableMonster()
    {
        isChasing = false;
    }

    private void Update()
    {
        if (player == null || !isEnabled || !isChasing)
            return;

        Vector3 targetPosition = new Vector3(
            player.position.x,
            transform.position.y,
            player.position.z
        );

        Vector3 direction =
            targetPosition - transform.position;

        direction.y = 0f;

        if (direction.sqrMagnitude <= 0.001f)
            return;

        direction.Normalize();

        transform.rotation =
            Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(direction),
                Time.deltaTime * 5f
            );

        characterController.Move(
            direction * moveSpeed * Time.deltaTime
        );
    }

    private void OnControllerColliderHit(
        ControllerColliderHit hit)
    {
        if (!hit.collider.CompareTag("Player"))
            return;

        if (PrototypeDeathManager.Instance != null)
        {
            PrototypeDeathManager.Instance.PlayerDied();
        }
    }
}