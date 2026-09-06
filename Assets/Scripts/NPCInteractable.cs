using UnityEngine;

public class NPCInteractable : MonoBehaviour, IInteractable
{
    [TextArea(2, 5)]
    public string dialogue =
        "تو قبلاً اینجا نبودی؟\n\n...نه، یادم نمیاد اصلاً چرا اینو پرسیدم.";

    public void Interact(InteractionUI ui)
    {
        if (ui != null)
        {
            ui.DisplayMessage(dialogue, 6f);
        }
    }

    public string GetInteractionPrompt()
    {
        return "[E] Talk";
    }
}