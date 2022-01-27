using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanerateMask : MonoBehaviour,IPointerClickHandler
{
    public List<GameObject> Targets;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("mask click!!");
        //OnlyBtn1WillTrigger(eventData);
        //BothWillTrigger(eventData);
        Raycast(eventData);
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

    
    private readonly List<RaycastResult> _rawRaycastResults = new List<RaycastResult>();
    
    private void Raycast(PointerEventData eventData)
    {
        _rawRaycastResults.Clear();
        EventSystem.current.RaycastAll(eventData, _rawRaycastResults);
        foreach (var rlt in _rawRaycastResults)
        {
            Debug.Log(rlt.gameObject);
            if (rlt.gameObject.GetComponent<IgnoreEventRaycast>())
            {
                continue;
            }
            ExecuteEvents.Execute(rlt.gameObject, eventData, ExecuteEvents.pointerClickHandler);
            //ExecuteEvents.ExecuteHierarchy(rlt.gameObject, eventData, ExecuteEvents.pointerClickHandler);
        }
    }
}
