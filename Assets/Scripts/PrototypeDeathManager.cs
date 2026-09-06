using UnityEngine;
using UnityEngine.SceneManagement;

public class PrototypeDeathManager : MonoBehaviour
{
    public static PrototypeDeathManager Instance { get; private set; }

    public int DeathCount { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayerDied()
    {
        DeathCount++;

        Debug.Log("PLAYER DIED - DeathCount = " + DeathCount);

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}