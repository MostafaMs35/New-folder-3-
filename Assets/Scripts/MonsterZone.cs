using UnityEngine;

public class MonsterZone : MonoBehaviour
{
    public MonsterAI monster;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (monster != null)
        {
            monster.EnableMonster();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (monster != null)
        {
            monster.DisableMonster();
        }
    }
}