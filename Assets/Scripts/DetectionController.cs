using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectionController : MonoBehaviour
{
    // on collision enter, check for collider's tag. If it's "detection" then check for it's second tag to see what check it requires. 

    public bool slippers = false;
    public bool window = false;
    public bool dog = false;

    public SpriteRenderer dogSleeping;
    public SpriteRenderer dogAwake;

    public DialogueHandler dialogueHandler;
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
                gran.enabled = true;
                Debug.Log("Caught by gran with boxes 1");

                boxes1up.enabled = false;
                SFXStart box1Audio = boxes1.GetComponent<SFXStart>();
                box1Audio.StartSFX();
                boxes1fall.enabled = true;

                DialogueWait2();
            }
            else if (tags.tags[0] == "boxes2")
            {
                interactionController.hiding = true;
                gran.enabled = true;
                Debug.Log("Caught by gran with boxes 2");

                boxes2up.enabled = false;
                SFXStart box2Audio = boxes2.GetComponent<SFXStart>();
                box2Audio.StartSFX();
                boxes2fall.enabled = true;

                StartCoroutine(DialogueWait2());
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

    IEnumerator DialogueWait2()
    {
        Debug.Log("Waiting for a second then restarting");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
