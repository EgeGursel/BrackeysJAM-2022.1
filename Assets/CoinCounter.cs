using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    private Animator _anim;
    private TextMeshProUGUI _text;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _anim = GetComponent<Animator>();
    }
    public void AddCoins(int amount)
    {
        _anim.SetTrigger("Add");
        _text.text = (int.Parse(_text.text) + amount).ToString();
    }
}
