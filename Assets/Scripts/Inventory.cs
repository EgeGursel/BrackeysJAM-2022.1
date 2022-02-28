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
    public void SwitchWeapon(int i)
    {
        
    }
}
