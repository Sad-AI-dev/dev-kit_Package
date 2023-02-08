using UnityEngine;

namespace DevKit {
    [AddComponentMenu("DevKit/Systems/Health System/Health Bars/Transform Health Bar")]
    public class TransformHealthBar : HealthBar
    {
        public Transform targetTransform;
        [Header("Scale Settings")]
        [SerializeField] private bool scaleX = true;
        [SerializeField] private bool scaleY;
        [SerializeField] private bool scaleZ;
        //vars
        private Vector3 startSize;

        private void Awake()
        {
            if (targetTransform == null) { targetTransform = transform; }
            startSize = targetTransform.localScale;
        }

        public override void UpdateHealthBar(float percentage)
        {
            Vector3 newScale = transform.localScale;
            if (scaleX) { newScale.x = percentage * startSize.x; }
            if (scaleY) { newScale.y = percentage * startSize.y; }
            if (scaleZ) { newScale.z = percentage * startSize.z; }
            targetTransform.localScale = newScale;
        }
    }
}
