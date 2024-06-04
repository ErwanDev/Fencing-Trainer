using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class NonDroppableGrabInteractable : XRGrabInteractable
{
    private bool isPickedUp = false;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        isPickedUp = true;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        if (!isPickedUp)
        {
            base.OnSelectExited(args);
        }
    }

}