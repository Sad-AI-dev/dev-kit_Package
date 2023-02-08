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
                if (obj.gameObject.activeSelf) {
                    obj.gameObject.SetActive(true);
                    return obj;
                }
            }
            return CreateNewObject();
        }

        private T CreateNewObject()
        {
            GameObject gO = Object.Instantiate(prefab, targetHolder);
            T obj = gO.GetComponent<T>();
            pool.Add(obj);
            return obj;
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
                if (gO.activeSelf) {
                    gO.SetActive(true);
                    return gO;
                }
            }
            return CreateNewObject();
        }

        private GameObject CreateNewObject()
        {
            GameObject obj = Object.Instantiate(prefab, targetHolder);
            pool.Add(obj);
            return obj;
        }
    }
}
