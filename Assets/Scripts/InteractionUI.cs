using UnityEngine;
using UnityEngine.UI;

public class InteractionUI : MonoBehaviour
{
    [Header("Message")]
    public GameObject messagePanel;
    public Text messageText;

    [Header("Prompt")]
    public Text promptText;

    // آیا پنجره پیام باز است؟
    private bool messageOpen = false;

    // برای PlayerInteraction
    public bool IsMessageOpen => messageOpen;

    private void Start()
    {
        if (messagePanel != null)
            messagePanel.SetActive(false);

        if (promptText != null)
            promptText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!messageOpen)
            return;

        // بستن پیام با E یا Space یا Escape
        if (Input.GetKeyDown(KeyCode.E) ||
            Input.GetKeyDown(KeyCode.Space) ||
            Input.GetKeyDown(KeyCode.Escape))
        {
            CloseMessage();
        }
    }

    public void ShowPrompt(string prompt)
    {
        // وقتی پیام باز است، Prompt نشان داده نشود
        if (messageOpen)
            return;

        if (promptText == null)
            return;

        promptText.text = prompt;
        promptText.gameObject.SetActive(true);
    }

    public void HidePrompt()
    {
        if (promptText == null)
            return;

        promptText.gameObject.SetActive(false);
    }

    public void DisplayMessage(string text, float duration = 0f)
    {
        if (messagePanel == null || messageText == null)
            return;

        messageText.text = text;
        messagePanel.SetActive(true);

        messageOpen = true;

        HidePrompt();
    }

    public void CloseMessage()
    {
        if (messagePanel != null)
            messagePanel.SetActive(false);

        messageOpen = false;
    }
}