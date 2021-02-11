using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Inventory;
    void Start()
    {
        Inventory.SetActive(false);
    }
    public void MangeInventoryButton()
    {
        if (Inventory.activeSelf)
        {
            Inventory.gameObject.SetActive(true);
        }
        else if (!Inventory.activeSelf)
        {
            Inventory.gameObject.SetActive(false);
        }
    }
}
