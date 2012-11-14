using UnityEngine;
using System;
using System.Collections;

public class ButtonControl : MonoBehaviour
{
    public Action Click;
    public Action<bool> Hover;
    public Action DoubleClick;

    private void OnClick()
    {
        if(Click != null)
        {
            Click();
        }
    }
}
