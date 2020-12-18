//author: Tim Bouwman
//Github: https://github.com/TimBouwman
using UnityEngine.XR.Interaction.Toolkit;

public class ClimbInteractibe : XRBaseInteractable
{
    protected override void Awake()
    {
        base.Awake();
        onSelectEnter.AddListener(Grab);
    }

    private void OnDestroy()
    {
        onSelectEnter.RemoveListener(Grab);
    }

    private void Grab(XRBaseInteractor interactor)
    {
        
    }
}