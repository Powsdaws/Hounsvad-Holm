using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPickup : MonoBehaviour
{
    public Item Item;


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
