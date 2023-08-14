using System;
using UnityEngine;
using UnityEngine.Events;

namespace DevKit {
    [AddComponentMenu("DevKit/Controllers/Mouse Input Receiver")]
    public class MouseInputReceiver : MonoBehaviour
    {
        [Serializable]
        public struct MouseButtonInput {
            public string name; //editor orginization
            public UnityEvent onButtonDown;
            public UnityEvent onButtonHeld;
            public UnityEvent onButtonUp;
            [Header("Input Code")]
            public int[] inputCodes;
        }

        [Tooltip("Used to read button inputs from mouse")]
        public MouseButtonInput[] buttonInputs;
        [Space(10)]

        [Tooltip("Used to read the scrollwheel")]
        public UnityEvent<float> onScrollWheelInput;
        [Tooltip("Used to read mouse movements")]
        public UnityEvent<Vector2> onMouseMove;

        //vars
        private Vector2 lastMousePos;

        private void Start()
        {
            lastMousePos = Input.mousePosition;
        }

        private void Update()
        {
            if (Time.timeScale > 0f) {
                ReadButtonInputs();
                ReadScrollWheel();
                ReadMouseMovements();
            }
        }

        //==================== Button Inputs ====================
        private void ReadButtonInputs()
        {
            for (int i = 0; i < buttonInputs.Length; i++) {
                ReadButtonInput(buttonInputs[i]);
            }
        }
        private void ReadButtonInput(MouseButtonInput input)
        {
            for (int i = 0; i < input.inputCodes.Length; i++) { 
                if (Input.GetMouseButtonDown(input.inputCodes[i])) { //don't break here, get mouse button will be called, which breaks
                    input.onButtonDown?.Invoke();
                }
                else if (Input.GetMouseButton(input.inputCodes[i])) {
                    input.onButtonHeld?.Invoke();
                    break;
                }
                else if (Input.GetMouseButtonUp(input.inputCodes[i])) {
                    input.onButtonUp?.Invoke();
                    break;
                }
            }
        }

        //==================== Scroll Wheel ====================
        private void ReadScrollWheel()
        {
            onScrollWheelInput?.Invoke(Input.mouseScrollDelta.y);
        }

        //==================== Mouse Movements ====================
        private void ReadMouseMovements()
        {
            onMouseMove?.Invoke((Vector2)Input.mousePosition - lastMousePos);
            lastMousePos = Input.mousePosition;
        }
    }
}
