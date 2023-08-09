using System.Collections;
using UnityEngine;

namespace DevKit {
    [AddComponentMenu("DevKit/Behaviours/Camera Shaker")]
    public class CameraShaker : MonoBehaviour
    {
        //vars
        private Vector3 startPos;
        private float currentMagnitude;

        private void Start()
        {
            startPos = transform.localPosition;
            currentMagnitude = 0;
        }

        public void ShakeCamera(float duration, float magnitude)
        {
            if (magnitude > currentMagnitude) { //only overwrite camshake when magnitude is higher
                //reset pos
                transform.localPosition = startPos;
                StopAllCoroutines();
                StartCoroutine(ShakeCo(duration, magnitude));
            }
        }

        private IEnumerator ShakeCo(float duration, float magnitude)
        {
            startPos = transform.localPosition;
            float elapsed = 0.0f;
            currentMagnitude = magnitude;
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
            //reset camera position
            transform.localPosition = startPos;
        }
    }
}
