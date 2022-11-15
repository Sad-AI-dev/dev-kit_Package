using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevKit {
    public class ObjectSpawner : MonoBehaviour
    {
        private enum SpawnMode {
            Wave,
            Random,
            Round_robin
        }
        public enum PrefabSelectMode {
            Random,
            Round_robin,
            Set
        }

        //-------modes-------
        [Tooltip("Dictates how objects are spawned.\n\n" +
            "Wave: spawns prefab at every point\n" +
            "Random: spawns prefab at a random point\n" +
            "Round_robin: spawns prefab at a single point, in order")]
        [SerializeField] private SpawnMode spawnMode;

        [Tooltip("Decides which prefab is selected.\n\n" +
            "Random: picks a random prefab\n" +
            "Round_robin: picks a prefab in order" +
            "Set: picks a predetermined prefab")]
        public PrefabSelectMode prefabSelectMode;

        [Header("Settings")]
        public List<GameObject> prefabs;
        [Space(10)]
        public List<Transform> spawnPoints;
        [Tooltip("==OPTIONAL==\n\n" +
            "transform that holds all spawnpoint transforms. used to auto compile spawnpoint list.")]
        [SerializeField] private Transform pointHolder;

        //round robin vars
        private int spawnSelectCounter = -1;
        private int prefabSelectCounter = -1;
        //set prefab vars
        private int prefabSelectIndex;

        private void Start() {
            prefabSelectIndex = 0;
        }

        //-----------spawn object--------------
        public void SpawnObject()
        {
            switch (spawnMode) {
                case SpawnMode.Wave:
                    SpawnAtAllPoints();
                    break;

                case SpawnMode.Random:
                    SpawnAtRandomPoint();
                    break;

                case SpawnMode.Round_robin:
                    SpawnRoundRobin();
                    break;
            }
        }

        public void SpawnObjectAtPrefabIndex(int index)
        {
            SetSelectIndex(index);
            SpawnObject();
        }
        private void SetSelectIndex(int index)
        {
            if (index > prefabs.Count - 1) {
                prefabSelectIndex = index % prefabs.Count;
            }
            else if (index >= 0) {
                prefabSelectIndex = index; //normal
            }
        }

        //------------spawn logic-----------
        private void SpawnAtAllPoints()
        {
            foreach (Transform t in spawnPoints) {
                SpawnAtPoint(t);
            }
        }

        private void SpawnAtRandomPoint()
        {
            SpawnAtPoint(spawnPoints[Random.Range(0, spawnPoints.Count)]);
        }

        private void SpawnRoundRobin()
        {
            spawnSelectCounter++;
            if (spawnSelectCounter >= spawnPoints.Count) { spawnSelectCounter = 0; }
            SpawnAtPoint(spawnPoints[spawnSelectCounter]);
        }

        //spawn object
        private void SpawnAtPoint(Transform t)
        {
            GameObject obj = Instantiate(GetPrefab());
            obj.transform.SetPositionAndRotation(t.position, t.rotation);
        }

        //---------------select prefab------------------
        private GameObject GetPrefab()
        {
            switch (prefabSelectMode) {
                case PrefabSelectMode.Random:
                    return prefabs[Random.Range(0, prefabs.Count)];

                case PrefabSelectMode.Round_robin:
                    prefabSelectCounter++;
                    if (prefabSelectCounter >= prefabs.Count) { prefabSelectCounter = 0; } //loop
                    return prefabs[prefabSelectCounter];

                case PrefabSelectMode.Set:
                    return prefabs[prefabSelectIndex];
            }
            return null;
        }

        //---------------------compile spawn points------------------------
        public void CompileSpawnPoints()
        {
            if (pointHolder != null) {
                spawnPoints.Clear();
                foreach (Transform child in pointHolder) {
                    spawnPoints.Add(child);
                }
            }
        }
    }
}