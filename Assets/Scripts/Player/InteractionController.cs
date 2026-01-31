using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public bool inRange;
    public Inventory inventory;

    private GameObject interactable;

    public Sprite ladder;

    private SpriteRenderer self;

    public bool hiding = false;

    public void Awake()
    {
        self = gameObject.GetComponent<SpriteRenderer>();
    }

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
            } else if (inventory.heldObject == "treats")
            {

            } else if (inventory.heldObject == "slippers")
            {

            } else if (inventory.heldObject == "leaflet")
            {

            } else if (inventory.heldObject == "key")
            {

            } else if (inventory.heldObject == "photo")
            {

            }
        }

        if (tags.tags[0] == "hide" && !hiding)
        {
            self.enabled = false;
            // play hide sound idk
            hiding = true;
        } else if (tags.tags[0] == "hide" && hiding)
        {
            self.enabled = true;
            // play hide sound again
            hiding = false;
        }
    }
}
