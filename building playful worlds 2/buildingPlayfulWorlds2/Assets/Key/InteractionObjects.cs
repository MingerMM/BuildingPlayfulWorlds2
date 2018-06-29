using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionObjects : MonoBehaviour {

    //volledig eigen code, geen tutorial

    float distanceKeyToPlayer;
    float distanceDoorToPlayer;

    public Transform player;
    public Transform key;
    public Transform door;

    public bool doorLocked;

    public int interactzone;

    public bool addKeyToInventory;

    public Inventory inventory;

    public GameObject keyObject;

	void Start () {
        doorLocked = true;
        addKeyToInventory = false;
	}
	
	
	void Update () {

        distanceKeyToPlayer = Vector3.Distance(key.position, player.position);
        distanceDoorToPlayer = Vector3.Distance(door.position, player.position);


        //staat voor de deur maar geen sleutel
        if ((distanceDoorToPlayer < interactzone) && doorLocked && Input.GetKeyDown("e"))
        {
            Debug.Log("The door is locked.");
        }

        //pakt sleutel op
        if ((distanceKeyToPlayer < interactzone) && Input.GetKeyDown("e"))
        {
            addKeyToInventory = true;
            inventory.SendMessage("ADDKEY");
            Debug.Log("You picked up the key.");
            keyObject.SetActive(false);     //Destroy (keyObject); werkt hier niet want dan kan hij niks meer in inventory stoppen
            doorLocked = false;
        }

        //staat voor de deur en wel sleutel
        if ((distanceDoorToPlayer < interactzone) && !doorLocked && Input.GetKeyDown("e"))
        {
            SceneManager.LoadScene("winningScene");
            Debug.Log("You won!");
        }
    }
}
