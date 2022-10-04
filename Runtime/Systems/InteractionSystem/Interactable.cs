using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent onInteractVoid;
    public UnityEvent<Interactor> onInteract;

    private List<Interactor> interactors;

    private void Start()
    {
        interactors = new List<Interactor>();
    }

    //--------------remove management-----------
    public void DestroyInteractable()
    {
        foreach (Interactor interactor in interactors) {
            interactor.RemoveInteractable(this);
        }
        Destroy(gameObject);
    }

    //-------------trigger events--------------
    private void OnTriggerEnter(Collider other) {
        AddToInteractor(other.gameObject);
    }
    private void OnTriggerExit(Collider other) {
        RemoveFromInteractor(other.gameObject);
    }

    //-----2D trigger events----
    private void OnTriggerEnter2D(Collider2D collision) {
        AddToInteractor(collision.gameObject);
    }
    private void OnTriggerExit2D(Collider2D collision) {
        RemoveFromInteractor(collision.gameObject);
    }

    //---on find interactor reactions---
    private void AddToInteractor(GameObject obj)
    {
        if (obj.TryGetComponent(out Interactor interactor)) {
            interactors.Add(interactor);
            interactor.AddInteractable(this);
        }
    }

    private void RemoveFromInteractor(GameObject obj)
    {
        if (obj.TryGetComponent(out Interactor interactor)) {
            interactors.Remove(interactor);
            interactor.RemoveInteractable(this);
        }
    }
}
