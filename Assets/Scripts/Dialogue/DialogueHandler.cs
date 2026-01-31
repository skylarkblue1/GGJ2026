using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHandler : MonoBehaviour
{
    // import text UI element
    private SpriteRenderer indicator;

    public List<string> mumDialogueLiving = new List<string>();
    public List<string> mumDialogueDetected = new List<string>();
    public List<string> dadDialogueLiving = new List<string>();
    public List<string> mumDialogueEnd = new List<string>();
    public List<string> dadDialogueEnd = new List<string>();
    public List<string> granDialogueKitchen = new List<string>();
    public List<string> granDialogueDetected = new List<string>();
    public List<string> granDialogueBasement = new List<string>();

    private EventHandler events;


    private void Start()
    {
        events = GameObject.Find("EventSystem").GetComponent<EventHandler>();
        indicator = gameObject.GetComponent<SpriteRenderer>();
    }

    public void StartNormalDialogue()
    {
        if (!events.dialogueActive)
        {
            indicator.enabled = true;
        }
    }

    IEnumerator DialogueWait()
    {
        yield return new WaitForSeconds(4.0f);

    }
}
