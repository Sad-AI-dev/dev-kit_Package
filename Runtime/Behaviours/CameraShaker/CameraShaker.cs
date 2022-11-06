using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevKit {
    public class CameraShaker : MonoBehaviour
    {
        [Header("shake settings")]
        public float falloffSpeed = 1.0f;
        //vars
        private float currentMagnitude;
    }
}
