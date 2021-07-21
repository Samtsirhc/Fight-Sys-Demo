using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    // 一般用在UI控件上，UI控件要挂载游戏内的物体上

    RectTransform rectTransform;
    Camera cam;
    Slider slider;
    Text text;


    Unit master;
    Vector3 fatherPos;
    float offset = 1.25f;
    private void Awake()
    {
        
        rectTransform = GetComponent<RectTransform>();
        slider = gameObject.GetComponent<Slider>();
        text = GetComponentInChildren<Text>();
        cam = Camera.main;
    }

    private void Start()
    {
    }
    private void Update()
    {
        SetPosition(this.offset);
        SetValue();
    }


    void SetPosition(float height_offset)
    {
        fatherPos = master.transform.position;
        Vector3 _tmp = fatherPos + new Vector3(0, height_offset, 0);
        Vector3 _pos = cam.WorldToScreenPoint(_tmp);
        rectTransform.position = _pos;
    }

    void SetValue()
    {
        float _value = master.curHp / master.maxHp;
        text.text = master.curHp.ToString();
        slider.value = _value;
    }

    public void SetMaster(Unit master)
    {
        this.master = master;
    }
}
