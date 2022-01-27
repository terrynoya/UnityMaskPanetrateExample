using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanerateMask : MonoBehaviour,IPointerClickHandler
{
    public List<GameObject> Targets;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("mask click!!");
        OnlyBtn1WillTrigger(eventData);
        //BothWillTrigger(eventData);
    }

    private void OnlyBtn1WillTrigger(PointerEventData eventData)
    {
        foreach (var target in Targets)
        {
            ExecuteEvents.Execute(target, eventData, ExecuteEvents.pointerClickHandler);    
        }
    }
    
    private void BothWillTrigger(PointerEventData eventData)
    {
        Debug.Log("BothWillTrigger!!");
        foreach (var target in Targets)
        {
            var comp = target.GetComponent<IPointerClickHandler>();
            if (comp != null)
            {
                ExecuteEvents.Execute(target, eventData, ExecuteEvents.pointerClickHandler);
            }    
            else
            {
                ExecuteEvents.ExecuteHierarchy(target, eventData, ExecuteEvents.pointerClickHandler);
            }    
        }
    }
}
