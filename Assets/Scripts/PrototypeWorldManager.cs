using UnityEngine;

public class PrototypeWorldManager : MonoBehaviour
{
    public GameObject roomLight;
    public GameObject closedDoor;

    private void Start()
    {
        if (PrototypeDeathManager.Instance == null)
        {
            Debug.LogError("PrototypeDeathManager پیدا نشد!");
            return;
        }

        int deathCount = PrototypeDeathManager.Instance.DeathCount;

        Debug.Log("WORLD START - DeathCount = " + deathCount);

        if (deathCount >= 1)
        {
            if (roomLight != null)
                roomLight.SetActive(false);

            if (closedDoor != null)
                closedDoor.SetActive(false);

            Debug.Log("DEATH 1 CONSEQUENCE APPLIED");
        }
    }
}