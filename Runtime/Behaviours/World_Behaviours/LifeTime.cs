using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DevKit {

    public class LifeTime : MonoBehaviour
    {
        public float lifeTime = 1f;
        private float startTime;
        [SerializeField] private bool destroyOnLifeTimeEnd = true;
        [SerializeField] private UnityEvent onLifeTimeEnd;

        private void Start()
        {
            startTime = lifeTime;
        }

        private void Update()
        {
            lifeTime -= Time.deltaTime;
            if (lifeTime < 0f) { OnTimerEnd(); }
        }

        private void OnTimerEnd()
        {
            onLifeTimeEnd?.Invoke();
            if (destroyOnLifeTimeEnd) { Destroy(gameObject); }
            else { 
                gameObject.SetActive(false);
                lifeTime = startTime;
            }
        }
    }
}
