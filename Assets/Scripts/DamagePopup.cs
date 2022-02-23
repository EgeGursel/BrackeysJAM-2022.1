using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    [HideInInspector] public int damage;
    private TextMesh _text;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TextMesh>();
        _text.text = damage.ToString();
    }
}
