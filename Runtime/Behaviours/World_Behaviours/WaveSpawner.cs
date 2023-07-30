using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DevKit {
    [AddComponentMenu("DevKit/Behaviours/Wave Spawner")]
    public class WaveSpawner : MonoBehaviour
    {
        public enum ActivateMode {
            Manual, Delay
        }

        [SerializeField] private bool spawnOnStart;
        [Tooltip("Dictates how waves are started\n\n" +
            "Manual: each wave must be manually started by another script.\n" +
            "Delay: waits for the final nextGroupDelay, then automatically spawns the next wave.")]
        [SerializeField] private ActivateMode activateMode;
        public UnityEvent onWaveEnd;

        [Header("Wave Content")]
        public List<WaveContentSO> waves;

        [Header("Spawn Points")]
        public OptionPicker<Transform> spawnPoints;
        [Space(10f)]
        [Tooltip("==OPTIONAL==\n\n" +
            "transform that holds all spawnpoint transforms. used to auto compile spawnpoint list.")]
        [SerializeField] private Transform pointHolder;

        //vars
        public bool IsSpawning { get; private set; }
        [HideInInspector] public int currentWave = 0;

        private void Start()
        {
            if (spawnOnStart) { SpawnNextWave(); }
        }

        public void SpawnNextWave()
        {
            if (!IsSpawning) {
                IsSpawning = true;
                StartCoroutine(SpawnWaveContentCo());
            }
        }

        private IEnumerator SpawnWaveContentCo()
        {
            foreach (WaveContentSO.ObjectGroup group in waves[currentWave].waveContent) {
                yield return StartCoroutine(SpawnObjectGroupCo(group));
            }
            OnWaveEnd();
        }
        private IEnumerator SpawnObjectGroupCo(WaveContentSO.ObjectGroup group)
        {
            for (int i = 0; i < group.count; i++) {
                SpawnObject(group.prefab);
                yield return new WaitForSeconds(group.nextObjectDelay);
            }
            yield return new WaitForSeconds(group.nextGroupDelay);
        }

        private void OnWaveEnd()
        {
            currentWave++;
            onWaveEnd?.Invoke();
            //handle activate mode
            if (activateMode == ActivateMode.Manual) {
                IsSpawning = false;
            }
            else { //spawn next wave
                StartCoroutine(SpawnWaveContentCo());
            }
        }

        //============ spawn objects ============
        private void SpawnObject(GameObject prefab)
        {
            Transform t = Instantiate(prefab).transform;
            t.position = spawnPoints.GetOption().position;
        }

        //=============== compile spawn points ===============
        public void CompileSpawnPoints()
        {
            if (pointHolder != null) {
                spawnPoints.options.options.Clear();
                foreach (Transform child in pointHolder) {
                    spawnPoints.options.options.Add(new WeightedChance<Transform>.WeightedOption { option = child, chance = 1f });
                }
            }
        }
    }
}