using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipMenager : MonoBehaviour
{
    public string message = "";

    public void OnPointerEnter()
    {
        if(message != "")
            Tooltip.Instance.show(message);
    }

    public void OnPointerExit()
    {
        Tooltip.Instance.hide();
    }
}
