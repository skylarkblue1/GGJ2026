using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public bool inRange;
    public Inventory inventory;

    private GameObject interactable;

    public Sprite ladder;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "interactable")
        {
            inRange = true;
            interactable = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "interactable")
        {
            inRange = false;
            interactable = null;
        }
    }

    void OnInteract()
    {
        Tags tags = interactable.GetComponent<Tags>();
        Sprite sprite = interactable.GetComponent<SpriteRenderer>().sprite;

        Debug.Log("Interacting");
        if (inRange && inventory.heldObject == "Empty" && tags.tags[1] == "pickup")
        {
            Debug.Log("trying to interact");
            inventory.heldObject = tags.tags[0];
            Debug.Log("New held object is: " + inventory.heldObject);
            interactable.SetActive(false);
        }

        // Any holy entities please forgive me for the coding sins I'm about to commit in this spaghetti code below

        if (inRange && inventory.heldObject == tags.tags[0] && tags.tags[1] == "placement")
        {
            if (inventory.heldObject == "ladder")
            {
                Debug.Log("Placing ladder");
                inventory.heldObject = "Empty";
                sprite = ladder; //not... changing sprite? Hopefully it works with actual sprites or idk
            } // else if (all the other items listed)
        }
    }
}
