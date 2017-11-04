using System;
using UnityEngine;
using VRTK;

public class MenuToggle : MonoBehaviour {
    public VRTK_ControllerEvents controllerEvents;
    public GameObject menu;

    private bool isShown = false;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        controllerEvents.TriggerPressed -= ControllerEvents_ButtonTwoPressed;
        controllerEvents.TriggerReleased -= ControllerEvents_ButtonTwoPressed;
    }

    private void ControllerEvents_ButtonTwoReleased(object sender, ControllerInteractionEventArgs e)
    {
        isShown = !isShown;
        menu.SetActive(isShown);
    }

    private void ControllerEvents_ButtonTwoPressed(object sender, ControllerInteractionEventArgs e)
    {
        throw new NotImplementedException();
    }
}
