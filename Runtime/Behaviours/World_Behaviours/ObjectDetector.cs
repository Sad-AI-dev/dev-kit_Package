using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DevKit {
    [AddComponentMenu("DevKit/Behaviours/Object Detector")]
    public class ObjectDetector : MonoBehaviour
    {
        public enum FilterMode {
            None,
            WhiteList,
            BlackList
        }

        [Header("Events")]
        public UnityEvent onDetectFirstObject;
        public UnityEvent onDetectObject;
        public UnityEvent onLeaveLastObject;

        [Header("Filter Settings")]
        [Tooltip("Determines how detected objects are filtered.\n\n" +
            "None: objects will not be filtered.\n" +
            "WhiteList: objects will be ignored, unless their tag is in the tagsToFilter list.\n" +
            "BlackList: objects will be ignored if their tag is in the tagsToFilter list.")]
        public FilterMode filterMode;
        [HideIf(nameof(FilterModeIsNone))]
        public List<string> tagsToFilter;

        //editor conditionals
        public bool FilterModeIsNone => filterMode == FilterMode.None;

        //vars
        private List<Transform> trackedObjects;

        private void Start() {
            trackedObjects = new();
        }

        //=========================== 2D detection ===========================
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

        //==================================== 3D detection ====================================
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

        //===================== util =====================
        private bool ValidObjectCheck(Transform toCheck)
        {
            return filterMode switch {
                FilterMode.WhiteList => IsInTagList(toCheck),
                FilterMode.BlackList => !IsInTagList(toCheck),
                _ => true,
            };
        }

        private bool IsInTagList(Transform toCheck)
        {
            foreach (string tag in tagsToFilter) {
                if (toCheck.CompareTag(tag)) { return true; }
            }
            return false;
        }
    }
}