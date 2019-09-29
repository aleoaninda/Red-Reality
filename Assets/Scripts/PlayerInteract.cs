using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

	public GameObject currentInterobj = null;
	public InteractionObject currentInterobjScript = null;
	public Inventory inventory;
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
