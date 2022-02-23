using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    [HideInInspector] public int damage;
    private TextMeshPro _text;
    public static DamagePopup Instance
    {
        get; private set;
    }
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TextMeshPro>();
        _text.text = damage.ToString();
    }
}
