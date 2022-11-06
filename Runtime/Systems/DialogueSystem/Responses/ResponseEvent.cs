using UnityEngine;
using UnityEngine.Events;

namespace DevKit {
    [System.Serializable]
    public class ResponseEvent
    {
        [HideInInspector] public string name;
        [SerializeField] private UnityEvent onResponse;

        public UnityEvent OnResponse => onResponse;
    }
}