using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public bool inRange;
    public Inventory inventory;

    private GameObject interactable;

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
        Debug.Log("Interacting");
        if (inRange && inventory.heldObject == "Empty")
        {
            Debug.Log("trying to interact");
            Tags tags = interactable.GetComponent<Tags>();
            inventory.heldObject = tags.tags[0];
            Debug.Log("New held object is: " + inventory.heldObject);
            interactable.SetActive(false);
        }
    }
}
