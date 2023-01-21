using System.Collections;
using UnityEngine;

namespace DevKit {
    [AddComponentMenu("DevKit/Behaviours/Camera Shaker")]
    public class CameraShaker : MonoBehaviour
    {
        public void ShakeCamera(float duration, float magnitude)
        {
            StartCoroutine(ShakeCo(duration, magnitude));
        }

        private IEnumerator ShakeCo(float duration, float magnitude)
        {
            Vector3 startPos = transform.localPosition;
            float elapsed = 0.0f;
            float currentMagnitude = magnitude;
            //shake camera
            while (elapsed < duration) {
                //step 1, set camera offset
                float x = Random.Range(-currentMagnitude, currentMagnitude);
                float y = Random.Range(-currentMagnitude, currentMagnitude);
                transform.localPosition = startPos + new Vector3(x, y);
                //step 2, lerp magnitude
                currentMagnitude = Mathf.Lerp(magnitude, 0.0f, (elapsed / duration));
                //step 3, update elapsed + wait
                elapsed += Time.deltaTime;
                yield return null;
            }
        }
    }
}
