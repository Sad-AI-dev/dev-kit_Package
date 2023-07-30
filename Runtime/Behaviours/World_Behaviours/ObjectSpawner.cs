using UnityEngine;

namespace DevKit {
    [AddComponentMenu("DevKit/Behaviours/Object Spawner")]
    public class ObjectSpawner : MonoBehaviour
    {
        [Header("Settings")]
        public OptionPicker<GameObject> prefabs = new OptionPicker<GameObject>();
        public OptionPicker<Transform> spawnPoints = new OptionPicker<Transform>();
        [Tooltip("==OPTIONAL==\n\n" +
            "transform that holds all spawnpoint transforms. used to auto compile spawnpoint list.")]
        [SerializeField] private Transform pointHolder;

        //============ spawn object modes ============
        public void SpawnObject()
        {
            InstantiateAtPoint(GetSpawnPoint(), GetPrefab());
        }

        public void SpawnObjectAtPrefabIndex(int index)
        {
            InstantiateAtPoint(GetSpawnPoint(), prefabs.GetOptionAtIndex(index));
        }

        public void SpawnAtAllPoints()
        {
            for (int i = 0; i < spawnPoints.options.Count; i++) {
                InstantiateAtPoint(spawnPoints.GetOptionAtIndex(i), GetPrefab());
            }
        }

        //===================== spawn logic =====================
        private void InstantiateAtPoint(Transform t, GameObject prefab)
        {
            GameObject obj = Instantiate(prefab);
            obj.transform.SetPositionAndRotation(t.position, t.rotation);
        }

        //====== select spawn point ======
        private Transform GetSpawnPoint()
        {
            return spawnPoints.GetOption();
        }

        //====== select prefab ======
        private GameObject GetPrefab()
        {
            return prefabs.GetOption();
        }

        //===================== compile spawn points =====================
        public void CompileSpawnPoints()
        {
            if (pointHolder != null) {
                //clear list
                spawnPoints.options.options.Clear();
                //add options
                foreach (Transform child in pointHolder) {
                    spawnPoints.options.options.Add(new WeightedChance<Transform>.WeightedOption { option = child, chance = 1f });
                }
            }
        }
    }
}