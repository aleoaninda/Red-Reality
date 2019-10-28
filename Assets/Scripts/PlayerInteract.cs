using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

	public GameObject currentInterobj = null;
	public InteractionObject currentInterobjScript = null;
    Inventory inventory;

    private void Start()
    {
        // Added by Tom to ensure that Inventory Component is automatically found
        inventory = GameObject.Find("player").GetComponent<Inventory>();
}

    private void Update()
	{
		if (Input.GetButtonDown ("Interact")&& currentInterobj)
		{
			if (currentInterobjScript.inventory)
			{
				inventory.AddItem(currentInterobj);
                currentInterobj = null;
                currentInterobjScript = null;
            }
			
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Interobject"))
		{
			Debug.Log(other.name);
			currentInterobj = other.gameObject;
			currentInterobjScript = currentInterobj.GetComponent<InteractionObject>();
		}
	}
}
