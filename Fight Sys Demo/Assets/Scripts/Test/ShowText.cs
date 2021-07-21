using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowText : MonoBehaviour
{
    private Text text;
    private void Awake()
    {
        text = GetComponent<Text>();
        gameObject.SetActive(false);
        EventCenter.AddListener<string>(EventType.SHOW_TEXT, Show);
    }
    private void OnDestroy()
    {
        EventCenter.RemoveListener<string>(EventType.SHOW_TEXT, Show);
    }
    public void Show(string str)
    {
        this.text.text = str;
        gameObject.SetActive(true);
    }
}
