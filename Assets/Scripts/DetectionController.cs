using UnityEngine;

public class DetectionController : MonoBehaviour
{
    // on collision enter, check for collider's tag. If it's "detection" then check for it's second tag to see what check it requires. 

    public bool slippers = false;
    public bool window = false;
    public bool dog = false;

    public SpriteRenderer dogSleeping;
    public SpriteRenderer dogAwake;

    public DialogueHandler  dialogueHandler;
    public InteractionController interactionController;

    public bool caughtbymum;
    public bool caughtbygran;

    public SpriteRenderer tvGlow;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "detection")
        {
            Tags tags = other.GetComponent<Tags>();
            if (tags.tags[0] == "slippers" && !slippers)
            {
                dialogueHandler.StartDialogue("CaughtGran");
                caughtbygran = true;
                interactionController.hiding = true;
                dogSleeping.enabled = false;
                dogAwake.enabled = true;
            }
            else if (tags.tags[0] == "window" && !window)
            {
                dialogueHandler.StartDialogue("CaughtMum");
                caughtbymum = true;
                interactionController.hiding = true;
                tvGlow.enabled = false;
            }
            else if (tags.tags[0] == "dog" && !dog)
            {
                dialogueHandler.StartDialogue("CaughtGran");
                caughtbygran = true;
                interactionController.hiding = true;
                dogSleeping.enabled = false;
                dogAwake.enabled = true;
            }
        }
        else if (other.tag == "instagameover")
        {
            Tags tags = other.GetComponent<Tags>();
            if (tags.tags[0] == "mum")
            {
                dialogueHandler.StartDialogue("CaughtMum");
                caughtbymum = true;
                interactionController.hiding = true;
                tvGlow.enabled = false;
            }
            else if (tags.tags[0] == "gran")
            {
                dialogueHandler.StartDialogue("CaughtGran");
                caughtbygran = true;
                interactionController.hiding = true;
                dogSleeping.enabled = false;
                dogAwake.enabled = true;
            }

        }

    }

}
