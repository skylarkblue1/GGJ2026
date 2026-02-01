using UnityEngine;
using UnityEngine.UIElements;

public class Inventory : MonoBehaviour
{
    //public string heldObject = "Empty";

    public Image slot1;
    public Image slot2;

    //[Header("Sprites for inventory icons")]
    public Sprite stoolIcon;
    public Sprite treatIcon;
    public Sprite leafletIcon;
    public Sprite keyIcon;
    public Sprite slippersIcon;
    public Sprite photoIcon;

    // make heldObject an array of 2, have additem class which checks if there is an empty space in the array and adds item. If not, sets bool in InteractionController to false
    public string[] heldObjects = new string[2];
    public int heldObjectsCount = 0;

    private void Start()
    {
        //slot1 = GameObject.Find("slot1").GetComponent<Image>();
        //slot2 = GameObject.Find("slot2").GetComponent<Image>();
    }

    public void AddItem(string itemName)
    {
        if (heldObjectsCount < heldObjects.Length)
        {
            heldObjects[heldObjectsCount] = itemName;
            heldObjectsCount++;

            //make the right sprite show

            if (heldObjectsCount == 1)
            {
                switch (itemName)
                {
                    case "stool":
                        //slot1.sprite = stoolIcon;
                        break;
                    case "treat":
                        //slot1.sprite = treatIcon;
                        break;
                    case "leaflet":
                        //slot1.sprite = leafletIcon;
                        break;
                    case "key":
                        //slot1.sprite = keyIcon;
                        break;
                    case "slippers":
                        //slot1.sprite = slippersIcon;
                        break;
                    case "photo":
                        //slot1.sprite = photoIcon;
                        break;
                }
            }
            else if (heldObjectsCount == 2)
            {
                switch (itemName)
                {
                    case "stool":
                        //slot2.sprite = stoolIcon;
                        break;
                    case "treat":
                        //slot2.sprite = treatIcon;
                        break;
                    case "leaflet":
                        //slot2.sprite = leafletIcon;
                        break;
                    case "key":
                        //slot2.sprite = keyIcon;
                        break;
                    case "slippers":
                        //slot2.sprite = slippersIcon;
                        break;
                    case "photo":
                        //slot2.sprite = photoIcon;
                        break;
                }
            }
        }
    }

    public void RemoveItem(string itemName)
    {
        for (int i = 0; i < heldObjects.Length; i++)
        {
            if (heldObjects[i] == itemName)
            {
                heldObjects[i] = null;
                heldObjectsCount--;
                if (i == 0)
                {
                    slot1 = null;
                }
                else if (i == 1)
                {
                    slot2 = null;
                }
                break;
            }
        }
    }
}
