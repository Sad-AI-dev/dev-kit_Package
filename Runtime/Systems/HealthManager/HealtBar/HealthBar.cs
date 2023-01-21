using UnityEngine;

namespace DevKit {
    public abstract class HealthBar : MonoBehaviour
    {
        public abstract void UpdateHealthBar(float percentage);
    }
}
