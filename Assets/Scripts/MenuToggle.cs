using System;
using UnityEngine;
using VRTK;

public class MenuToggle : MonoBehaviour {
    public VRTK_ControllerEvents controllerEvents;
    public GameObject menu;

    private bool isShown = false;

    private void OnEnable()
    {
        controllerEvents.ButtonTwoPressed += ControllerEvents_ButtonTwoPressed;
        controllerEvents.ButtonTwoReleased += ControllerEvents_ButtonTwoReleased;
    }

    private void OnDisable()
    {
        controllerEvents.ButtonTwoPressed -= ControllerEvents_ButtonTwoPressed;
        controllerEvents.ButtonTwoReleased -= ControllerEvents_ButtonTwoPressed;
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
