using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DevKit {
public class Interactor : MonoBehaviour
{
    [Header("Events")]
    [Tooltip("triggers when the interactor comes in range of the first interactable")]
    public UnityEvent onCanInteract;
    [Tooltip("triggers when the interactor leaves the range of the last interactable")]
    public UnityEvent onStopCanInteract;
    //vars
    private List<Interactable> interactables;

    private void Start()
    {
        interactables = new List<Interactable>();
    }

    //---------------interactables management------------------
    public void AddInteractable(Interactable interactable)
    {
        interactables.Add(interactable);
        if (interactables.Count == 1) {
            onCanInteract?.Invoke();
        }
    }

    public void RemoveInteractable(Interactable interactable)
    {
        interactables.Remove(interactable);
        if (interactables.Count == 0) { onStopCanInteract.Invoke(); }
    }

    //----------------interact with interactable---------------
    public bool TryInteract()
    {
        if (interactables.Count > 0) {
            SortInteractables(); //interact with closest interactable
            interactables[0].onInteract?.Invoke(this);
            return true;
        }
        return false;
    }

    private void SortInteractables()
    {
        interactables.Sort((Interactable a, Interactable b) => 
            Vector3.Distance(transform.position, a.transform.position).CompareTo(Vector3.Distance(transform.position, b.transform.position))
        );
    }
}
}
