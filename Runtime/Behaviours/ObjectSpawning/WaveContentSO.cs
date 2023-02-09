using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevKit {
    [CreateAssetMenu(menuName = "ScriptableObjects/DevKit/WaveContent")]
    public class WaveContentSO : ScriptableObject
    {
        [System.Serializable]
        public class ObjectGroup {
            public GameObject prefab;
            public int count;
            [Header("Timings")]
            public float nextObjectDelay = 1f;
            public float nextGroupDelay = 2f;
        }

        public List<ObjectGroup> waveContent;
    }
}
