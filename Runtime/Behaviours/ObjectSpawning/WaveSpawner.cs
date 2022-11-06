using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevKit {
public class WaveSpawner : MonoBehaviour
{
    public enum ActivateMode {
        Manual, Delay
    }
    public enum SpawnPointSelectMode {
        Random, Round_robin
    }
    public enum ObjectSelectMode {
        In_order, Random
    }

    [System.Serializable]
    public struct WaveData
    {
        [System.Serializable]
        public struct PrefabCount
        {
            public GameObject prefab;
            public int count;
        }

        public string name; //header for editor
        public List<PrefabCount> content;
        [Header("Timings")]
        [Tooltip("Delay between every object spawned")]
        public float spawnDelay;
        [Tooltip("When set to 'Delay' mode, Time to wait before spawning next wave")]
        public float waveDelay;
    }

    //vars
    [Tooltip("Dictates how waves are started\n\n" +
        "Manual: each wave must be manually started by another script.\n" +
        "Delay: waits for a delay, then automatically spawns the next wave.")]
    public ActivateMode activateMode;
    [SerializeField] private bool spawnOnStart;
    [Tooltip("When set to true, final wave can be repeated.")]
    [SerializeField] private bool repeatFinalWave;

    [Header("Technical Modes")]
    [Tooltip("Dictates which spawnpoint is chosen when spawning a prefab\n\n" +
        "Random: a random point is chosen.\n" +
        "Round_robin: points are chosen in order.")]
    public SpawnPointSelectMode spawnPointSelectMode;

    [Tooltip("Dictates the order objects within a wave are spawned in\n\n" +
        "In_order: objects are spawned in the order of the content list.\n" +
        "Random: objects are spawned in a random order.")]
    public ObjectSelectMode objectSelectMode;

    [Header("Waves")]
    public List<WaveData> waves;
    [Space(10)]
    public List<Transform> spawnPoints;
    [Space(10)]
    [Tooltip("==OPTIONAL==\n\n" +
        "transform that holds all spawnpoint transforms. used to auto compile spawnpoint list.")]
    [SerializeField] private Transform pointHolder;

    //spawn vars
    private int waveNum = 0;
    private List<WaveData.PrefabCount> currentWave;
    //states
    private bool isSpawning = false;

    //round robin vars
    private int spawnIndex = -1;

    private void Start()
    {
        if (spawnOnStart) { SpawnWave(); }
    }

    //-------------start wave spawn--------------
    public void SpawnWave()
    {
        if (!isSpawning) {
            if (waveNum < waves.Count) { //check if next next wave exists
                StartSpawnWave();
            }
            else if (repeatFinalWave && waveNum == waves.Count) { //spawned final wave, can repeat
                waveNum--;
                StartSpawnWave();
            }
        }
    }

    private void StartSpawnWave()
    {
        UpdateSpawnVars();
        //start wave spawning
        StartCoroutine(SpawnWaveCo());
    }
    private void UpdateSpawnVars()
    {
        isSpawning = true;
        currentWave = new List<WaveData.PrefabCount>(waves[waveNum].content);
    }

    //---------------spawning logic-------------------------
    private IEnumerator SpawnWaveCo()
    {
        while (currentWave.Count > 0) {
            yield return new WaitForSeconds(waves[waveNum].spawnDelay);
            SpawnObject();
        }
        //end spawning
        StartCoroutine(OnEndWave());
    }
    private IEnumerator OnEndWave()
    {
        isSpawning = false;
        if (activateMode == ActivateMode.Delay) {
            //start next wave after delay
            yield return new WaitForSeconds(waves[waveNum].waveDelay);
            waveNum++;
            SpawnWave();
        }
        else { waveNum++; }
    }

    private void SpawnObject()
    {
        GameObject obj = Instantiate(GetPrefab());
        Transform targetPoint = GetSpawnPoint();
        obj.transform.SetPositionAndRotation(targetPoint.position, targetPoint.rotation);
    }

    //-----------------get prefab--------------------
    private GameObject GetPrefab()
    {
        switch (objectSelectMode) {
            case ObjectSelectMode.In_order:
                return GetNextObject();

            case ObjectSelectMode.Random:
                return GetRandomObject();
        }
        return null;
    }

    private GameObject GetNextObject()
    {
        GameObject target = currentWave[0].prefab;
        //register spawn
        RegisterObjectSpawn(0);
        //return result
        return target;
    }

    private GameObject GetRandomObject()
    {
        int rand = Random.Range(0, currentWave.Count);
        GameObject target = currentWave[rand].prefab;
        //register spawn
        RegisterObjectSpawn(rand);
        //return result
        return target;
    }

    private void RegisterObjectSpawn(int index)
    {
        currentWave[index] = new WaveData.PrefabCount { count = currentWave[index].count - 1, prefab = currentWave[index].prefab };
        if (currentWave[index].count <= 0) { //if type is depleted, remove type
            currentWave.RemoveAt(index);
        }
    }

    //----------------get spawn point-----------------
    private Transform GetSpawnPoint()
    {
        switch (spawnPointSelectMode) {
            case SpawnPointSelectMode.Random:
                return spawnPoints[Random.Range(0, spawnPoints.Count)];

            case SpawnPointSelectMode.Round_robin:
                spawnIndex++;
                if (spawnIndex >= spawnPoints.Count) { spawnIndex = 0; } //loop
                return spawnPoints[spawnIndex];
        }
        return null;
    }

    //--------------spawn point registration---------------
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