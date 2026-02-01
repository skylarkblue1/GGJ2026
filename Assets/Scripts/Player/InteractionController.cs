using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionController : MonoBehaviour
{
    public bool inRange;
    public Inventory inventory;

    private GameObject interactable;
    
    [Header("Sprites for it being placed down")]
    public SpriteRenderer stoolPlaced;
    public SpriteRenderer treatsPlaced;
    public SpriteRenderer leafletPlaced;
    //public SpriteRenderer keyPlaced;
    public SpriteRenderer photoPlaced;

    [Header("Interact colliders")]
    public PolygonCollider2D stool;
    public PolygonCollider2D treats;
    public PolygonCollider2D leaflet;
    public PolygonCollider2D photo;

    [Header("The rest of the stuff")]
    public Sprite windowOpen;
    public Sprite windowClose;

    [Header("Gran Placements")]
    public SpriteRenderer gran1;
    public SpriteRenderer gran2;

    // public Sprite dogAwake;

    public BoxCollider2D basementDoor;
    public BoxCollider2D endingDoor;

    private SpriteRenderer self;

    public bool hiding = false;

    private Tags tags;
    private Sprite sprite;

    public SpriteRenderer ePrompt;

    public DetectionController detection;

    public DialogueHandler dialogue;

    public SpriteRenderer mum1;
    public SpriteRenderer mum2;

    public void Awake()
    {
        self = gameObject.GetComponent<SpriteRenderer>();

        mum1 = GameObject.Find("Mum1").GetComponent<SpriteRenderer>();
        mum2 = GameObject.Find("Mum2").GetComponent<SpriteRenderer>();

        dialogue = GameObject.Find("Subtitles").GetComponent<DialogueHandler>();
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
        if (inRange && inventory.heldObjectsCount < 2 && tags.tags[1] == "pickup")
        {
            Debug.Log("trying to interact");
            inventory.AddItem(tags.tags[0]);
            Debug.Log("New held object is: " + tags.tags[0]);
            interactable.SetActive(false);

            if (tags.tags[0] == "key")
            {
                detection.dog = true;
                basementDoor.enabled = true;
            }

            if (tags.tags[0] == "photo")
            {
                endingDoor.enabled = true;
            }
        }

        if (inRange && tags.tags[0] == "slippers")
        {
            detection.slippers = true;
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

        if (inRange && tags.tags[1] == "placement")
        {
            if (inventory.heldObjects[0] == tags.tags[0] | inventory.heldObjects[1] == tags.tags[0])
            {
                switch (tags.tags[0])
                {
                    case "stool":
                        Debug.Log("Placing stool");
                        stool.enabled = false;
                        break;
                    case "treats":
                        Debug.Log("Placing treats");
                        treats.enabled = false;
                        detection.dogSleeping.enabled = false;
                        gran1.enabled = false;
                        detection.dogAwake.enabled = true;
                        gran2.enabled = true;
                        break;
                    case "leaflet":
                        Debug.Log("Placing leaflet");
                        leaflet.enabled = false;
                        break;
                    case "photo":
                        Debug.Log("Placing photo");
                        photo.enabled = false;
                        photoPlaced.enabled = true;
                        Ending();
                        break;
                }

                inventory.RemoveItem(tags.tags[0]);
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

    private void Ending()
    {
        mum1.enabled = false;
        mum2.enabled = true;
        detection.tvGlow.enabled = false;
        hiding = true;


        dialogue.StartDialogue("Ending");
        dialogue.whichDialogue = "Ending";

    }
}
