using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevKit {
    public class BehaviourPool<T> where T : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        public Transform targetHolder;
        //vars
        public List<T> pool;

        public T GetBehaviour()
        {
            foreach (T obj in pool) {
                if (obj.gameObject.activeSelf) { return obj; }
            }
            return CreateNewObject();
        }

        private T CreateNewObject()
        {
            GameObject gO = Object.Instantiate(prefab, targetHolder);
            return gO.GetComponent<T>();
        }
    }

    public class ObjectPool
    {
        [SerializeField] private GameObject prefab;
        public Transform targetHolder;
        //vars
        public List<GameObject> pool;

        public GameObject GetObject()
        {
            foreach (GameObject gO in pool) {
                if (gO.activeSelf) { return gO; }
            }
            return CreateNewObject();
        }

        private GameObject CreateNewObject()
        {
            return Object.Instantiate(prefab, targetHolder);
        }
    }
}
