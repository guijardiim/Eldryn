
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public GameObject dialogueUI;

    private bool playerNearby = false;
    private bool dialogueOpen = false;

    void Start()
    {
        dialogueUI.SetActive(false);
    }

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.Z))
        {
            dialogueOpen = !dialogueOpen;

            dialogueUI.SetActive(dialogueOpen);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            dialogueOpen = false;
            dialogueUI.SetActive(false);
        }
    }
}
