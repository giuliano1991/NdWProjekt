using UnityEngine;
using VRTK;

public class OpenMenuByButton : MonoBehaviour
{
    public GameObject menu;

    private bool menuVisible;

    private void Start()
    {

        menuVisible = false;

        if (GetComponent<VRTK_ControllerEvents>() == null)
        {
            VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_ControllerEvents_ListenerExample", "VRTK_ControllerEvents", "the same"));
            return;
        }

        GetComponent<VRTK_ControllerEvents>().GripPressed += new ControllerInteractionEventHandler(DoGripPressed);
    }

    private void DoGripPressed(object sender, ControllerInteractionEventArgs e)
    {
        menuVisible = !menuVisible;
        menu.SetActive(menuVisible);
    }

 }