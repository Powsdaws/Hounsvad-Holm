using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPickup : MonoBehaviour
{
    public Item Item;

    //Scriptet skal p� objektet som skal kunne samles op, sammen med "Item" scriptet.

    void Pickup()
    {
        //Tilf�jer item til liste 
        inventoryManager.Instance.Add(Item);
        //�del�gger gameobjektet
        Destroy(gameObject);
    }


    private void OnMouseDown()
    {
        //Kalder p� pickup funktionen
        //Husk collider p� objekterne
        Pickup();
    }
}
