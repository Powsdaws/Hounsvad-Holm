using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPickup : MonoBehaviour
{
    public Item Item;

    //Scriptet skal på objektet som skal kunne samles op, sammen med "Item" scriptet.

    void Pickup()
    {
        //Tilføjer item til liste 
        inventoryManager.Instance.Add(Item);
        //Ødelægger gameobjektet
        Destroy(gameObject);
    }


    private void OnMouseDown()
    {
        //Kalder på pickup funktionen
        //Husk collider på objekterne
        Pickup();
    }
}
