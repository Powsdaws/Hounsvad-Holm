using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


//Husk tilføj empty til scene 
//Scriptet tilføjes dertil
public class inventoryManager : MonoBehaviour
{
    public static inventoryManager Instance;
    public List<Item> Items = new List<Item>();

    //Vis i inventory...
    public Transform ItemContent;
    public GameObject InventoryItem;


    //Enable Remove
    public Toggle EnableRemove;


    public inventoryItemController[] InventoryItems;

    private void Awake()
    {
        Instance = this;
    }


    //Tilføjer item til liste
    public void Add(Item item)
    {
        Items.Add(item);

    }


    //Fjerner item fra liste
    public void Remove(Item item)
    {
        Items.Remove(item);
    }



    public void ListItems()
    {

        //Clean content before open
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }



        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
            
            if(EnableRemove.isOn)
            {
                removeButton.gameObject.SetActive(true);
            }

        }

        SetInventoryItems();
    }


    public void EnableItemsRemove()
    {
        if (EnableRemove.isOn)
        {
            foreach (Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(false);
            }
        }
    }

    public void SetInventoryItems()
    {
        InventoryItems = ItemContent.GetComponentsInChildren<inventoryItemController>();

        for (int i = 0; i < Items.Count; i++)
        {
            InventoryItems[i].AddItem(Items[i]);
        }
    }
}
