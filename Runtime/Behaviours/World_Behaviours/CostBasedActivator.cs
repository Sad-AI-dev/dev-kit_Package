using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DevKit {
    [AddComponentMenu("DevKit/Behaviours/Cost Based Activator")]
    public class CostBasedActivator : MonoBehaviour
    {
        [System.Serializable]
        public class Option : ISerializationCallbackReceiver {
            public string name;
            public int price;
            public UnityEvent onSelect;
            [HideInInspector] public bool initialized;

            public void OnBeforeSerialize() { }
            public void OnAfterDeserialize() {
                if (!initialized) {
                    price = 1;
                    initialized = true;
                }
            }
        }

        public enum ActivateMode {
            Manual, Interval
        }

        public enum SaveMode {
            None, Random, Interval, Interval_Random
        }

        [Header("Budget Settings")]
        public int budget;
        [SerializeField] private bool activateOnStart;
        [Space(10f)]
        //gain values
        public int budgetGain;
        public int GainRampup;
        public int GainRampupFrequency;
        [Space(10f)]
        //gain mode values
        [Tooltip("Determines when behavior is activated.\n\n" +
            "Manual: only activates when Activate() is called.\n" +
            "Interval: activates periodically.\n")]
        public ActivateMode activateMode;
        [Tooltip("Only used when 'Activate Mode' is set to 'Interval'.\n" +
            "Determines the interval in seconds.")]
        public float ActivateIntervalTime;

        [Header("Save Behavior Settings")]
        [Tooltip("Determines how the save behavior is activated.\n\n" +
            "None: save behavior will never be activated.\n" +
            "Random: save behavior will randomly be activated.\n" +
            "Interval: save behavior will be activated once per set interval.\n" +
            "Interval_Random: similar to 'Interval', but interval time is randomly picked.")]
        public SaveMode saveMode;

        [HideIf(nameof(SaveModeDisabled))]
        [Range(0f, 100f)] public float minSavePercent;
        [HideIf(nameof(SaveModeDisabled))]
        [Range(0f, 100f)] public float maxSavePercent;

        [Tooltip("Only used when 'Save Mode' is set to 'Random'.\n" +
            "Determines the chance for the save behavior to activate, in percentage.")]
        [HideIf(nameof(SaveModeNotRandom))]
        [Range(0f, 100f)] public float saveChance;
        [Tooltip("Only used when 'Save Mode' is set to 'Interval'.\n" +
            "Determines after how many budget gains the save behavior should activate.")]
        [HideIf(nameof(SaveModeNotInterval))]
        public int saveInterval;
        [Tooltip("Only used when 'Save Mode' is set to 'Interval_Random'.")]
        [HideIf(nameof(SaveModeNotIntervalRandom))]
        public int minRandInterval;
        [Tooltip("Only used when 'Save Mode' is set to 'Interval_Random'.")]
        [HideIf(nameof(SaveModeNotIntervalRandom))]
        public int maxRandInterval;

        [Header("Options")]
        [SerializeField] private List<Option> options;

        //editor conditionals
        public bool SaveModeDisabled => saveMode == SaveMode.None;
        public bool SaveModeNotRandom => saveMode != SaveMode.Random;
        public bool SaveModeNotInterval => saveMode != SaveMode.Interval;
        public bool SaveModeNotIntervalRandom => saveMode != SaveMode.Interval_Random;

        //vars
        private int rampupCounter;
        private int savedBudget;
        private int saveCounter;
        private bool stopReq;

        //option decision vars
        private int minPrice;

        //editor pollish
        private float oldMinSave;
        private float oldMinInterval;

        private void Start()
        {
            minPrice = CalcMinPrice();
            if (saveMode == SaveMode.Interval_Random) { SetNewRandSaveInterval(); }
            if (activateOnStart) { Activate(); }
        }

        //-------------------activate---------------------
        public void Activate()
        {
            //step 1: purchace options
            PurchaseOptions(); //makes start budget more intuitive + allows for showing current budget in editor
            //step 2: gain budget
            GainBudget();
            //step 3: save behavior
            if (saveMode != SaveMode.None) { HandleSaveBehavior(); }
            //repeat?
            if (activateMode == ActivateMode.Interval) {
                StartCoroutine(ActivateIntervalCo());
            }
        }
        private IEnumerator ActivateIntervalCo()
        {
            yield return new WaitForSeconds(ActivateIntervalTime);
            if (!stopReq) { Activate(); }
            else { stopReq = false; } //reset stopReq
        }

        //--------------------stop----------------
        public void Stop()
        {
            stopReq = true;
        }

        //-----------------gain budget step---------------
        private void GainBudget()
        {
            budget += budgetGain;
            HandleSavedBudget();
            HandleRampup();
        }

        private void HandleSavedBudget()
        {
            budget += savedBudget;
            savedBudget = 0;
        }

        private void HandleRampup()
        {
            rampupCounter++;
            if (rampupCounter == GainRampupFrequency) {
                budgetGain += GainRampup;
                rampupCounter = 0;
            }
        }

        //------------------save step---------------------
        private void HandleSaveBehavior()
        {
            switch (saveMode) {
                case SaveMode.Random:
                    HandleRandomSave(); break;

                case SaveMode.Interval:
                case SaveMode.Interval_Random:
                    HandleIntervalSave(); break;
            }
        }

        private void HandleRandomSave()
        {
            if (Random.Range(0.0f, 100.0f) < saveChance) {
                SaveBudget();
            }
        }

        private void HandleIntervalSave()
        {
            saveCounter++;
            if (saveCounter >= saveInterval) {
                if (saveMode == SaveMode.Interval_Random) { SetNewRandSaveInterval(); }
                SaveBudget();
                saveCounter = 0;
            }
        }
        private void SetNewRandSaveInterval()
        {
            saveInterval = Random.Range(minRandInterval, maxRandInterval + 1);
        }

        private void SaveBudget()
        {
            int toSave = Mathf.RoundToInt((Random.Range(minSavePercent, maxSavePercent) / 100) * budget);
            savedBudget = toSave;
            budget -= toSave;
        }

        //----------------purchase step------------------
        private void PurchaseOptions()
        {
            while (budget >= minPrice) {
                List<Option> availableOptions = GetAvailableOptions();
                Option chosenOption = availableOptions[Random.Range(0, availableOptions.Count)];
                budget -= chosenOption.price; //pay
                chosenOption.onSelect?.Invoke();
            }
        }

        //-------price calcs-------
        private int CalcMinPrice()
        {
            int minPrice = options[0].price;
            for (int i = 1; i < options.Count - 1; i++) {
                if (options[i].price < minPrice) {
                    minPrice = options[i].price;
                }
            }
            return minPrice;
        }

        private List<Option> GetAvailableOptions()
        {
            List<Option> availables = new List<Option>();
            foreach (Option option in options) {
                if (option.price <= budget) {
                    availables.Add(option);
                }
            }
            return availables;
        }

        //-------------------manage options list----------------------
        public void AddOption(Option option)
        {
            options.Add(option);
            minPrice = CalcMinPrice();
        }

        public bool RemoveOption(Option option)
        {
            if (options.Contains(option)) {
                options.Remove(option);
                minPrice = CalcMinPrice();
                return true;
            }
            return false;
        }

        //----------------------editor pollish------------------------
        private void OnValidate()
        {
            SavePercentageCheck();
            SaveIntervalCheck();
            if (options != null) {
                ValidPricesCheck();
            }
        }

        //save percentage check
        private void SavePercentageCheck()
        {
            if (minSavePercent > maxSavePercent) {
                if (minSavePercent != oldMinSave) {
                    maxSavePercent = minSavePercent; //min moved, move max up to min
                }
                else {
                    minSavePercent = maxSavePercent; //max moved, move min down to max
                }
                UpdateOldPercentVars();
            }
        }
        private void UpdateOldPercentVars()
        {
            oldMinSave = minSavePercent;
        }

        //save rand interval check
        private void SaveIntervalCheck()
        {
            if (minRandInterval > maxRandInterval) {
                if (minRandInterval != oldMinInterval) {
                    maxRandInterval = minRandInterval; //min moved, move max up to min
                }
                else {
                    minRandInterval = maxRandInterval; //max moved, move min down to max
                }
            }
            UpdateOldIntervalVars();
        }
        private void UpdateOldIntervalVars()
        {
            oldMinInterval = minRandInterval;
        }

        //valid prices check
        private void ValidPricesCheck()
        {
            foreach (Option opt in options) {
                if (opt.price <= 0) {
                    Debug.LogWarning($"{transform.name}: option {opt.name} has an invalid price, please make sure price is higher than 0!");
                }
            }
        }
    }
}