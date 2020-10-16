using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    public static UIHealthBar healtBar { get; private set; }
    public Image mask;
    float orinalSize;

    private void Awake()//It's called when the object is created, in this case when the game starts
    {
        healtBar = this;//this = Special C# keyword that means "the object that currently runs that function"
    }

    // Start is called before the first frame update
    void Start()
    {
        orinalSize = mask.rectTransform.rect.width;
    }

    public void SetValue(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, orinalSize * value);
    }  
}
