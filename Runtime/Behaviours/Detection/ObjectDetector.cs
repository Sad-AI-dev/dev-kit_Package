using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectDetector : MonoBehaviour
{
    [Header("Events")]
    public UnityEvent onDetectFirstObject;
    public UnityEvent onDetectObject;
    public UnityEvent onLeaveLastObject;

    [Header("Settings")]
    public List<string> ignoreTags;

    private List<Transform> trackedObjects;

    private void Start() {
        trackedObjects = new();
    }

    //---------------------------2D detection-------------------------------
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ValidObjectCheck(collision.transform)) {
            onDetectObject?.Invoke();
            if (trackedObjects.Count <= 0) { onDetectFirstObject?.Invoke(); } //check if just detected first object
            if (!trackedObjects.Contains(collision.transform)) { trackedObjects.Add(collision.transform); } //track object
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (ValidObjectCheck(collision.transform)) {
            trackedObjects.Remove(collision.transform); //stop tracking object
            if (trackedObjects.Count <= 0) { onLeaveLastObject?.Invoke(); } //check if just left last object
        }
    }

    //------------------------------------3D detection-------------------------------------------------
    private void OnTriggerEnter(Collider collision)
    {
        if (ValidObjectCheck(collision.transform)) {
            if (trackedObjects.Count <= 0) { onDetectFirstObject?.Invoke(); } //check if just detected first object
            if (!trackedObjects.Contains(collision.transform)) { trackedObjects.Add(collision.transform); } //track object
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (ValidObjectCheck(collision.transform)) {
            trackedObjects.Remove(collision.transform); //stop tracking object
            if (trackedObjects.Count <= 0) { onLeaveLastObject?.Invoke(); } //check if just left last object
        }
    }

    //-----------------------util-------------------------
    private bool ValidObjectCheck(Transform toCheck)
    {
        foreach (string tag in ignoreTags) {
            if (toCheck.CompareTag(tag)) { return false; }
        }
        return true;
    }
}