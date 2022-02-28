using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<GameObject> weapons = new List<GameObject>();
     private KeyCode[] keyCodes = {
         KeyCode.Alpha1,
         KeyCode.Alpha2,
         KeyCode.Alpha3,
         KeyCode.Alpha4,
         KeyCode.Alpha5,
     };

     
    void Start()
    {
        foreach (Transform child in transform)
        {
            weapons.Add(child.gameObject);
        }
    }
    void Update()
    {
        for(int i = 0 ; i < keyCodes.Length; i ++ )
        {
            if(Input.GetKeyDown(keyCodes[i]))
            {
                SwitchWeapon(i);
            }
        }
    }
    public void SwitchWeapon(int index)
    {
        foreach (GameObject weapon in weapons)
        {
            weapon.SetActive(false);
        }
        weapons[index].SetActive(true);
        Debug.Log("Switched to " + weapons[index].name);
    }
}
