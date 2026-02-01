using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionController : MonoBehaviour
{
    public bool inRange;
    public Inventory inventory;

    private GameObject interactable;

    public SpriteRenderer ladder;
    public SpriteRenderer treats;
    public SpriteRenderer slippers;
    public SpriteRenderer leaflet;
    public SpriteRenderer key;
    public SpriteRenderer photo;

    public Sprite windowOpen;
    public Sprite windowClose;

    private SpriteRenderer self;

    public bool hiding = false;

    private Tags tags;
    private Sprite sprite;

    public SpriteRenderer ePrompt;

    public DetectionController detection;

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

            ePrompt.enabled = true;

            tags = interactable.GetComponent<Tags>();
            sprite = interactable.GetComponent<SpriteRenderer>().sprite;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "interactable")
        {
            inRange = false;
            interactable = null;

            ePrompt.enabled = false;
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

        if (inRange && tags.tags[0] == "window")
        {
            if (tags.tags[1] == "toopen")
            {
                interactable.GetComponent<SpriteRenderer>().sprite = windowOpen;
                detection.window = true;
                //Start playing window sound
            }
        }

        // check if tag 0 is door, if yes, check tag1 for location and load that scene
        if (inRange && tags.tags[0] == "door")
        {
            SceneManager.LoadScene(tags.tags[1]);
        }

        // Any holy entities please forgive me for the coding sins I'm about to commit in this spaghetti code below - 4am edit - this comment applies to this entire project now.

        if (inRange && inventory.heldObject == tags.tags[0] && tags.tags[1] == "placement")
        {
            switch (inventory.heldObject)
            {
                case "ladder":
                    Debug.Log("Placing ladder");
                    ladder.enabled = true;
                    break;
                case "treats":
                    Debug.Log("Placing treats");
                    treats.enabled = true;
                    break;
                case "leaflet":
                    Debug.Log("Placing leaflet");
                    leaflet.enabled = true;
                    break;
                case "photo":
                    Debug.Log("Placing photo");
                    photo.enabled = true;
                    break;
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
