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

    public SpriteRenderer boxes1up;
    public SpriteRenderer boxes1fall;
    public SpriteRenderer boxes2up;
    public SpriteRenderer boxes2fall;

    public SpriteRenderer gran;

    public GameObject boxes1;
    public GameObject boxes2;

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
            else if (tags.tags[0] == "boxes1")
            {
                interactionController.hiding = true;
                dialogueHandler.StartDialogue("CaughtGran");
                caughtbygran = true;
                gran.enabled = true;

                boxes1up.enabled = false;
                SFXStart box1Audio = boxes1.GetComponent<SFXStart>();
                box1Audio.StartSFX();
                boxes1fall.enabled = true;
            } else if (tags.tags[0] == "boxes2")
            {
                interactionController.hiding = true;
                dialogueHandler.StartDialogue("CaughtGran");
                caughtbygran = true;
                gran.enabled = true;

                boxes2up.enabled = false;
                SFXStart box2Audio = boxes2.GetComponent<SFXStart>();
                box2Audio.StartSFX();
                boxes2fall.enabled = true;
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
