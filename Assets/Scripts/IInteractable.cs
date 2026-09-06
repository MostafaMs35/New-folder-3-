public interface IInteractable
{
    void Interact(InteractionUI ui);
    string GetInteractionPrompt();
}