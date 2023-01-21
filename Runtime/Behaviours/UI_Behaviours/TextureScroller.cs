using UnityEngine;
using UnityEngine.UI;

namespace DevKit {
    [AddComponentMenu("DevKit/Behaviours/UI Behaviours/Texture Scroller")]
    public class TextureScroller : MonoBehaviour
    {
        [Header("Scroll Settings")]
        public float scrollSpeed = 1;
        public Vector2 scrollDirection;

        //vars
        [HideInInspector] public Image imgShower;

        private void Update()
        {
            //scroll texture
            float offset = Time.time * scrollSpeed;
            imgShower.material.SetTextureOffset("_MainTex", scrollDirection.normalized * offset);
        }

        //-------------get image component-------------
        public void InitializeImage()
        {
            imgShower = GetComponent<Image>();
            if (!imgShower) {
                Debug.LogWarning(name + ": no image found on this object!");
            }
        }
    }
}
