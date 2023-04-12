using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Husk tilf�j empty til scene 
//Scriptet tilf�jes dertil
public class inventoryManager : MonoBehaviour
{
    public static inventoryManager Instance;
    public List<Item> Items = new List<Item>();


    private void Awake()
    {
        Instance = this;
    }


    //Tilf�jer item til liste
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
