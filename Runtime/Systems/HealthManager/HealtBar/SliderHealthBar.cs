using UnityEngine;
using UnityEngine.UI;

namespace DevKit {
    [AddComponentMenu("DevKit/Systems/Health System/Health Bars/Slider Health Bar")]
    public class SliderHealthBar : HealthBar
    {
        public Slider targetSlider;
        public Image fillImage;
        public Gradient gradient;

        private void Awake()
        {
            if (targetSlider == null) { Debug.LogError("No healthbar slider was set on " + transform.name + "!"); }
            targetSlider.minValue = 0f;
            targetSlider.maxValue = 1f;
        }

        public override void UpdateHealthBar(float percentage)
        {
            targetSlider.value = (percentage);
            fillImage.color = gradient.Evaluate(percentage);
        }
    }
}
