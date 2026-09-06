using UnityEngine;

public class DocumentInteractable : MonoBehaviour, IInteractable
{
    [TextArea(3, 10)]
    public string documentContent =
        "THE GATE REMAINS WHILE THE KEEPER REMAINS.\n\n" +
        "If the keeper is forgotten,\n" +
        "the gate will no longer exist.";

    public float displayTime = 6f;

    public void Interact(InteractionUI ui)
    {
        if (ui != null)
        {
            ui.DisplayMessage(documentContent, displayTime);
        }
    }

    public string GetInteractionPrompt()
    {
        return "[E] Read";
    }
}