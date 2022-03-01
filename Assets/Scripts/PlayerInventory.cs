using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<string> _inventory = new List<string>();
    private int _currIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            _inventory.Add(child.name);
        }
        _currIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SwitchItem();
        }
    }
    private void SwitchItem()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        if (_currIndex + 1 < _inventory.Count)
        {
            _currIndex++;
        }
        else
        {
            _currIndex = 0;
        }
        transform.GetChild(_currIndex).gameObject.SetActive(true);
    }
}
