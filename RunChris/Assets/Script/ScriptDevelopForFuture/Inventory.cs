using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject Perfabs;
    Dictionary<ItemUI, Item> items;
    // Start is called before the first frame update
    void Start()
    {
        items = new Dictionary<ItemUI, Item>();
    }
    public void AddItem(Item item)  
    {
        
        GameObject prefabsitem = Instantiate(Perfabs, new Vector3(0, 0, 0), Quaternion.identity, transform)as GameObject;

        items.Add(prefabsitem.GetComponent<ItemUI>(), item);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
