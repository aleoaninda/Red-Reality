using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
	public GameObject[] inventory = new GameObject[10];
	public Button[] InventoryButtons = new Button[10];
	public GameObject inventoryUI;

	public void AddItem(GameObject item)
	{
		bool itemAdded = false;
		for (int i=0; i < inventory.Length; i++)
		{
			if (inventory [i] == null)
			{
				inventory[i] = item;
				//InventoryButtons[i].name = item.name;
				InventoryButtons[i].image.overrideSprite = item.GetComponent<SpriteRenderer>().sprite;
                //InventoryButtons[i].GetComponent<PanelOpener>.GetType();
                //NOTE: dynamically change the panel name
				itemAdded = true;
				item.SendMessage("DoInteraction");
                PuzzleRepo.AddPuzzle(int.Parse(item.name));
				break;
			}
		}
		if (!itemAdded)
		{
			Debug.Log("Inventory is full");
		}
	}
	void Update()
	{
		// Check to see if we should open/close the inventory
		if (Input.GetButtonDown("Inventory"))
		{
			inventoryUI.SetActive(!inventoryUI.activeSelf);
		}
	}
}
