using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public bool inRange;
    public Inventory inventory;

    private GameObject interactable;

    public Sprite ladder;
    public Sprite treats;
    public Sprite slippers;
    public Sprite leaflet;
    public Sprite key;
    public Sprite photo;

    private SpriteRenderer self;

    public bool hiding = false;

    private Tags tags;
    private Sprite sprite;

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

            tags = interactable.GetComponent<Tags>();
            sprite = interactable.GetComponent<SpriteRenderer>().sprite;

            if (tags.tags[0] == "detection")
            {
                // trigger class in detection script this script is already too long
            }
            
            if (tags.tags[0] == "disturbance")
            {
                if (tags.tags[1] == "dog")
                {

                } else if (tags.tags[1] == "boxes")
                {

                }
            }
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
                sprite = ladder; //not... changing sprite? Hopefully it works with actual sprites or idk
            } else if (inventory.heldObject == "treats")
            {
                Debug.Log("Placing treats");
                sprite = treats;
            } else if (inventory.heldObject == "slippers")
            {
                Debug.Log("Placing slippers");
                sprite = slippers;
            } else if (inventory.heldObject == "leaflet")
            {
                Debug.Log("Placing leaflet");
                sprite = leaflet;
            } else if (inventory.heldObject == "key")
            {
                Debug.Log("Placing key");
                sprite = key;
            } else if (inventory.heldObject == "photo")
            {
                Debug.Log("Placing photo");
                sprite = photo;
            }

            inventory.heldObject = "Empty";
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
