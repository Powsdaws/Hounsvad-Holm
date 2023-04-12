using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPickup : MonoBehaviour
{
    public Item Item;


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
