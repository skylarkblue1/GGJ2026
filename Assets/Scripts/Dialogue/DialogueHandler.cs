using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using Unity.VisualScripting;

public class DialogueHandler : MonoBehaviour
{
    // import text UI element
    private SpriteRenderer mumIndicator;
    private SpriteRenderer dadIndicator;
    private SpriteRenderer granIndicator;

    public List<string> DialogueLivingRoom = new List<string>();
    public List<string> mumDialogueDetected = new List<string>();
    public List<string> DialogueEnd = new List<string>();
    public List<string> DialogueKitchen = new List<string>();
    public List<string> granDialogueDetected = new List<string>();
    public List<string> DialogueBasement = new List<string>();

    private EventHandler events;

    private TextMeshProUGUI subtitles;

    public string whichDialogue;

    private string whoSpeaking;
    private int dialogueCount = 0;

    private string dialogueString;


    private void Start()
    {
        events = GameObject.Find("EventSystem").GetComponent<EventHandler>();
        mumIndicator = GameObject.Find("MumIndicator").GetComponent<SpriteRenderer>();
        dadIndicator = GameObject.Find("DadIndicator").GetComponent<SpriteRenderer>();
        //granIndicator = GameObject.Find("GranIndicator").GetComponent<SpriteRenderer>();

        subtitles = gameObject.GetComponent<TextMeshProUGUI>();

        StartNormalDialogue("LivingRoom");
    }

    public void StartNormalDialogue(string location)
    {
        whichDialogue = location;

        if (!events.dialogueActive)
        {
            if (whichDialogue == "LivingRoom")
            {
                LivingRoomDialogue(0);
            } else if (whichDialogue == "Kitchen")
            {

            } else if (whichDialogue == "Ending")
            {

            } else if (whichDialogue == "CaughtMum")
            {

            } else if (whichDialogue == "CaughtGran")
            {

            } else if (whichDialogue == "Basement")
            {

            }

        }
    }

    private void LivingRoomDialogue(int count)
    {
        dialogueCount = count;

        if (dialogueCount > 12)
        {
            dialogueCount = 0;
            subtitles.text = "";
            StartCoroutine(DialogueWait3());
        }

        // post text, if dialogue count is xyz delay for that long, increase count, loop back around
        if (dialogueCount == 0 || dialogueCount == 1 || dialogueCount == 4 || dialogueCount == 5 || dialogueCount == 9 || dialogueCount == 10)
        {
            whoSpeaking = "<color=\"blue\">Dad:</color>";
            dadIndicator.enabled = true;
            mumIndicator.enabled = false;
        }
        else
        {
            whoSpeaking = "<color=\"red\">Mum:</color>";
            mumIndicator.enabled = true;
            dadIndicator.enabled = false;
        }

        dialogueString = whoSpeaking + " " + DialogueLivingRoom[dialogueCount];

        subtitles.text = dialogueString;

        if (dialogueCount == 0 || dialogueCount == 1 || dialogueCount == 2 || dialogueCount == 7)
        {
            StartCoroutine(DialogueWait5());
        } else if (dialogueCount == 5 || dialogueCount == 8 || dialogueCount == 10)
        {
            StartCoroutine(DialogueWait4());
        } else if (dialogueCount == 3 || dialogueCount == 4 || dialogueCount == 6 || dialogueCount == 9 || dialogueCount == 11)
        {
            StartCoroutine(DialogueWait3());
        } else if (dialogueCount == 12)
        {
            StartCoroutine(DialogueWait6());
        }

    }

    IEnumerator DialogueWait6()
    {
        yield return new WaitForSeconds(6.0f);
        dialogueCount++;
        if (whichDialogue == "LivingRoom")
        {
            LivingRoomDialogue(dialogueCount);
        }
        else if (whichDialogue == "Kitchen")
        {

        }
        else if (whichDialogue == "Ending")
        {

        }
        else if (whichDialogue == "CaughtMum")
        {

        }
        else if (whichDialogue == "CaughtGran")
        {

        }
        else if (whichDialogue == "Basement")
        {

        }
    }
    IEnumerator DialogueWait5()
    {
        yield return new WaitForSeconds(5.0f);
        dialogueCount++;
        if (whichDialogue == "LivingRoom")
        {
            LivingRoomDialogue(dialogueCount);
        }
        else if (whichDialogue == "Kitchen")
        {

        }
        else if (whichDialogue == "Ending")
        {

        }
        else if (whichDialogue == "CaughtMum")
        {

        }
        else if (whichDialogue == "CaughtGran")
        {

        }
        else if (whichDialogue == "Basement")
        {

        }
    }
    IEnumerator DialogueWait4()
    {
        yield return new WaitForSeconds(4.0f);
        dialogueCount++;
        if (whichDialogue == "LivingRoom")
        {
            LivingRoomDialogue(dialogueCount);
        }
        else if (whichDialogue == "Kitchen")
        {

        }
        else if (whichDialogue == "Ending")
        {

        }
        else if (whichDialogue == "CaughtMum")
        {

        }
        else if (whichDialogue == "CaughtGran")
        {

        }
        else if (whichDialogue == "Basement")
        {

        }
    }
    IEnumerator DialogueWait3()
    {
        yield return new WaitForSeconds(3.0f);
        dialogueCount++;
        if (whichDialogue == "LivingRoom")
        {
            LivingRoomDialogue(dialogueCount);
        }
        else if (whichDialogue == "Kitchen")
        {

        }
        else if (whichDialogue == "Ending")
        {

        }
        else if (whichDialogue == "CaughtMum")
        {

        }
        else if (whichDialogue == "CaughtGran")
        {

        }
        else if (whichDialogue == "Basement")
        {

        }
    }
}
