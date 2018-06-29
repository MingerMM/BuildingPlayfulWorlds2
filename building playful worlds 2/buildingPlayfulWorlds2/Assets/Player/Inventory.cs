using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    // volledig eigen code, geen tutorial


    public GameObject[] inventory = new GameObject[1];

    public GameObject keyObject;

    public InteractionObjects interactionObjects;

    
    void Start () {
		
	}
	
	
	void Update () {

        for(int i = 0; i < inventory.Length; i++)
        {
            if (interactionObjects.addKeyToInventory == true)
            {
                inventory[i] = keyObject;
                Debug.Log(keyObject.name + " was added");
                interactionObjects.doorLocked = false;
            }
        }

    }

    public void ADDKEY()
    {
        Debug.Log("deze pakt hij.");

        for (int i = 0; i < inventory.Length; i++)
        {
                inventory[i] = keyObject;
                Debug.Log(keyObject.name + " was added");
                //interactionObjects.doorLocked = false;
            
        }
    }
}
