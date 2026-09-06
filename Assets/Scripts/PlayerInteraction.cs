using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactDistance = 2.5f;
    public LayerMask interactLayer;
    public Transform cameraTransform;
    public InteractionUI interactionUI;

    private IInteractable currentInteractable;

    private void Start()
    {
        if (cameraTransform == null && Camera.main != null)
            cameraTransform = Camera.main.transform;
    }

    private void Update()
{
    if (interactionUI != null && interactionUI.IsMessageOpen)
        return;

    CheckForInteractable();

    if (Input.GetKeyDown(KeyCode.E) &&
        currentInteractable != null)
    {
        currentInteractable.Interact(interactionUI);
    }
}

    private void CheckForInteractable()
    {
        currentInteractable = null;

        if (cameraTransform == null)
            return;

        Ray ray = new Ray(
            cameraTransform.position,
            cameraTransform.forward
        );

        if (Physics.Raycast(
            ray,
            out RaycastHit hit,
            interactDistance,
            interactLayer))
        {
            IInteractable interactable =
                hit.collider.GetComponentInParent<IInteractable>();

            if (interactable != null)
            {
                currentInteractable = interactable;

                if (interactionUI != null)
                {
                    interactionUI.ShowPrompt(
                        interactable.GetInteractionPrompt()
                    );
                }

                return;
            }
        }

        if (interactionUI != null)
            interactionUI.HidePrompt();
    }
}