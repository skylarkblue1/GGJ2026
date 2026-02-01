using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public DetectionController detectionController;

    private string dialogueString;


    private void Start()
    {
        events = GameObject.Find("EventSystem").GetComponent<EventHandler>();
        mumIndicator = GameObject.Find("MumIndicator").GetComponent<SpriteRenderer>();
        dadIndicator = GameObject.Find("DadIndicator").GetComponent<SpriteRenderer>();
        //granIndicator = GameObject.Find("GranIndicator").GetComponent<SpriteRenderer>();

        subtitles = gameObject.GetComponent<TextMeshProUGUI>();

        //For testing
        StartDialogue("LivingRoom");
    }

    private void Update()
    {
        // when dialogue count = 2, and whichdialogue = caughtmum, restart level
        if (whichDialogue == "CaughtMum" && dialogueCount == 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (whichDialogue == "CaughtGran" && dialogueCount == 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void StartDialogue(string location)
    {
        dialogueCount = 0;
        whichDialogue = location;

        if (!events.dialogueActive)
        {
            if (whichDialogue == "LivingRoom")
                LivingRoomDialogue(0);
            else if (whichDialogue == "Kitchen")
                KitchenDialogue(0);
            else if (whichDialogue == "Ending")
                EndingDialogue(0);
            else if (whichDialogue == "Basement")
                BasementDialogue(0);
        }
        else if (whichDialogue == "CaughtMum")
        {
            CaughtMumDialogue(0);
        }
        else if (whichDialogue == "CaughtGran")
        {
            CaughtGranDialogue(0);
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

        if (dialogueCount == 1 || dialogueCount == 2 || dialogueCount == 7)
            StartCoroutine(DialogueWait5());
        else if (dialogueCount == 5 || dialogueCount == 8 || dialogueCount == 10 || dialogueCount == 0)
            StartCoroutine(DialogueWait4());
        else if (dialogueCount == 3 || dialogueCount == 4 || dialogueCount == 6 || dialogueCount == 9 || dialogueCount == 11)
            StartCoroutine(DialogueWait3());
        else if (dialogueCount == 12)
            StartCoroutine(DialogueWait6());

    }

    private void KitchenDialogue(int count)
    {
        dialogueCount = count;

        if (dialogueCount > 12)
        {
            dialogueCount = 0;
            subtitles.text = "";
            StartCoroutine(DialogueWait3());
        }

        dialogueString = "<color=\"Green\">Gran: </color>" + DialogueKitchen[dialogueCount];

        subtitles.text = dialogueString;

        if (dialogueCount == 3 || dialogueCount == 4)
            StartCoroutine(DialogueWait4());
        else if (dialogueCount == 0 || dialogueCount == 1 || dialogueCount == 2 || dialogueCount == 5)
            StartCoroutine(DialogueWait3());
    }

    private void EndingDialogue(int count)
    {
        dialogueCount = count;

        if (dialogueCount > 12)
        {
            dialogueCount = 0;
            subtitles.text = "";
            StartCoroutine(DialogueWait3());
        }

        // post text, if dialogue count is xyz delay for that long, increase count, loop back around
        if (dialogueCount == 0 || dialogueCount == 2 || dialogueCount == 3 || dialogueCount == 6 || dialogueCount == 7 || dialogueCount == 11)
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

        dialogueString = whoSpeaking + " " + DialogueEnd[dialogueCount];

        subtitles.text = dialogueString;

        if (dialogueCount == 1 || dialogueCount == 8 || dialogueCount == 11)
            StartCoroutine(DialogueWait5());
        else if (dialogueCount == 2 || dialogueCount == 4 || dialogueCount == 5 || dialogueCount == 6 || dialogueCount == 7 || dialogueCount == 10 || dialogueCount == 13)
            StartCoroutine(DialogueWait4());
        else if (dialogueCount == 0 || dialogueCount == 3 || dialogueCount == 9)
            StartCoroutine(DialogueWait3());
        else if (dialogueCount == 12)
            StartCoroutine(DialogueWait2());
    }

    private void CaughtMumDialogue(int count)
    {
        dialogueCount = count;

        if (dialogueCount > 12)
        {
            dialogueCount = 0;
            subtitles.text = "";
            StartCoroutine(DialogueWait3());
        }

        dialogueString = "<color=\"Red\">Mum: </color>" + mumDialogueDetected[dialogueCount];

        subtitles.text = dialogueString;

        if (dialogueCount == 0)
            StartCoroutine(DialogueWait3());
        else if (dialogueCount == 1 || dialogueCount == 2)
            StartCoroutine(DialogueWait5());
    }

    private void CaughtGranDialogue(int count)
    {
        dialogueCount = count;

        if (dialogueCount > 12)
        {
            dialogueCount = 0;
            subtitles.text = "";
            StartCoroutine(DialogueWait3());
        }

        dialogueString = "<color=\"Green\">Gran: </color>" + granDialogueDetected[dialogueCount];

        subtitles.text = dialogueString;

        if (dialogueCount == 1)
            StartCoroutine(DialogueWait4());
        else if (dialogueCount == 2)
            StartCoroutine(DialogueWait3());
        else if (dialogueCount == 0)
            StartCoroutine(DialogueWait5());
    }

    private void BasementDialogue(int count)
    {
        dialogueCount = count;

        if (dialogueCount > 12)
        {
            dialogueCount = 0;
            subtitles.text = "";
            StartCoroutine(DialogueWait3());
        }

        dialogueString = "<color=\"Green\">Gran: </color>" + DialogueBasement[dialogueCount];

        subtitles.text = dialogueString;
        
        StartCoroutine(DialogueWait3());
    }

    IEnumerator DialogueWait6()
    {
        try
        {
            dialogueCount++;
        }
        catch
        {
            dialogueCount = 0;
        }
        yield return new WaitForSeconds(6.0f);
        if (detectionController.caughtbymum)
            whichDialogue = "CaughtMum";
        else if (detectionController.caughtbygran)
            whichDialogue = "CaughtGran";



        switch (whichDialogue)
        {
            case "LivingRoom":
                LivingRoomDialogue(dialogueCount);
                break;
            case "Kitchen":
                KitchenDialogue(dialogueCount);
                break;
            case "Ending":
                EndingDialogue(dialogueCount);
                break;
            case "Basement":
                BasementDialogue(dialogueCount);
                break;
            case "CaughtMum":
                CaughtMumDialogue(dialogueCount);
                break;
            case "CaughtGran":
                CaughtGranDialogue(dialogueCount);
                break;
        }
    }
    IEnumerator DialogueWait5()
    {
        try
        {
            dialogueCount++;
        }
        catch
        {
            dialogueCount = 0;
        }
        yield return new WaitForSeconds(5.0f);

        if (detectionController.caughtbymum)
            whichDialogue = "CaughtMum";
        else if (detectionController.caughtbygran)
            whichDialogue = "CaughtGran";



        switch (whichDialogue)
        {
            case "LivingRoom":
                LivingRoomDialogue(dialogueCount);
                break;
            case "Kitchen":
                KitchenDialogue(dialogueCount);
                break;
            case "Ending":
                EndingDialogue(dialogueCount);
                break;
            case "Basement":
                BasementDialogue(dialogueCount);
                break;
            case "CaughtMum":
                CaughtMumDialogue(dialogueCount);
                break;
            case "CaughtGran":
                CaughtGranDialogue(dialogueCount);
                break;
        }
    }
    IEnumerator DialogueWait4()
    {
        try
        {
            dialogueCount++;
        }
        catch
        {
            dialogueCount = 0;
        }
        yield return new WaitForSeconds(4.0f);

        if (detectionController.caughtbymum)
            whichDialogue = "CaughtMum";
        else if (detectionController.caughtbygran)
            whichDialogue = "CaughtGran";



        switch (whichDialogue)
        {
            case "LivingRoom":
                LivingRoomDialogue(dialogueCount);
                break;
            case "Kitchen":
                KitchenDialogue(dialogueCount);
                break;
            case "Ending":
                EndingDialogue(dialogueCount);
                break;
            case "Basement":
                BasementDialogue(dialogueCount);
                break;
            case "CaughtMum":
                CaughtMumDialogue(dialogueCount);
                break;
            case "CaughtGran":
                CaughtGranDialogue(dialogueCount);
                break;
        }
    }
    IEnumerator DialogueWait3()
    {
        try
        {
            dialogueCount++;
        }
        catch
        {
            dialogueCount = 0;
        }
        yield return new WaitForSeconds(3.0f);

        if (detectionController.caughtbymum)
            whichDialogue = "CaughtMum";
        else if (detectionController.caughtbygran)
            whichDialogue = "CaughtGran";



        switch (whichDialogue)
        {
            case "LivingRoom":
                LivingRoomDialogue(dialogueCount);
                break;
            case "Kitchen":
                KitchenDialogue(dialogueCount);
                break;
            case "Ending":
                EndingDialogue(dialogueCount);
                break;
            case "Basement":
                BasementDialogue(dialogueCount);
                break;
            case "CaughtMum":
                CaughtMumDialogue(dialogueCount);
                break;
            case "CaughtGran":
                CaughtGranDialogue(dialogueCount);
                break;
        }
    }

    IEnumerator DialogueWait2()
    {
        try
        {
            dialogueCount++;
        }
        catch
        {
            dialogueCount = 0;
        }
        yield return new WaitForSeconds(2.0f);

        if (detectionController.caughtbymum)
            whichDialogue = "CaughtMum";
        else if (detectionController.caughtbygran)
            whichDialogue = "CaughtGran";



        switch (whichDialogue)
        {
            case "LivingRoom":
                LivingRoomDialogue(dialogueCount);
                break;
            case "Kitchen":
                KitchenDialogue(dialogueCount);
                break;
            case "Ending":
                EndingDialogue(dialogueCount);
                break;
            case "Basement":
                BasementDialogue(dialogueCount);
                break;
            case "CaughtMum":
                CaughtMumDialogue(dialogueCount);
                break;
            case "CaughtGran":
                CaughtGranDialogue(dialogueCount);
                break;
        }
    }
}
