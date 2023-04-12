using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Husk tilføj empty til scene 
//Scriptet tilføjes dertil
public class inventoryManager : MonoBehaviour
{
    public static inventoryManager Instance;
    public List<Item> Items = new List<Item>();


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
}
