using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace DevKit {
    [AddComponentMenu("DevKit/Behaviours/Interval Timer Manager")]
    public class IntervalTimerManager : MonoBehaviour
    {
        public enum TimerLengthMode {
            Set, Random
        }

        [System.Serializable]
        public class IntervalTimer {
            public bool activateOnStart;
            [Header("Time Settings")]
            public float timerLength;
            public int repeatCount;
            [Tooltip("Determines timer length when repeating, has the following options:\n\n" +
                "Set: uses the 'timerLength' variable on repeats\n" +
                "Random: uses a random number between 'minTimerLength' and 'maxTimerLength'")]
            public TimerLengthMode timerLengthMode;
            [Header("Random Time Settings")]
            public float minTimerLength;
            public float maxTimerLength;
            [Header("Events")]
            public UnityEvent onTimerActivated;
            public UnityEvent onTimerEnded;

            //vars
            [HideInInspector] public float oldMinTimer;
        }

        public UnityDictionary<string, IntervalTimer> intervalTimers;

        private void Start() {
            foreach (IntervalTimer timer in intervalTimers.Values) {
                if (timer.activateOnStart) { ActivateTimer(timer); }
            }
        }

        //----------------------activate timer-------------------
        public Coroutine ActivateTimer(string timerName)
        {
            if (intervalTimers.ContainsKey(timerName)) {
                return ActivateTimer(intervalTimers[timerName]);
            }
            //nothing found, throw warning
            Debug.LogWarning($"{name}: No timer with name {timerName} was found!");
            return null;
        }

        public Coroutine ActivateTimer(IntervalTimer timer)
        {
            return StartCoroutine(IntervalTimerCo(timer));
        }

        //-----------------------run timer----------------------
        private IEnumerator IntervalTimerCo(IntervalTimer timer)
        {
            int counter = 0;
            while (true) {
                //wait
                yield return new WaitForSeconds(GetWaitTime(timer));
                //invoke event
                timer.onTimerActivated?.Invoke();
                //done check
                if (counter == timer.repeatCount) {
                    timer.onTimerEnded?.Invoke();
                    break;
                }
                counter++; //update after check, repeatCount: 0 means 'no repeat'
            }
        }

        private float GetWaitTime(IntervalTimer timer)
        {
            switch (timer.timerLengthMode) {
                default:
                case TimerLengthMode.Set:
                    return timer.timerLength;

                case TimerLengthMode.Random:
                    return Random.Range(timer.minTimerLength, timer.maxTimerLength);
            }
        }

        //---------------------manage timers-------------------
        public IntervalTimer GetTimer(string timerName)
        {
            if (intervalTimers.ContainsKey(timerName)) {
                return intervalTimers[timerName];
            }
            return null;
        }

        //-----------------------editor pollish-----------------------
        private void OnValidate()
        {
            if (intervalTimers != null) {
                foreach (IntervalTimer timer in intervalTimers.Values) {
                    RandomTimerBoundsCheck(timer);
                }
            }
        }

        private void RandomTimerBoundsCheck(IntervalTimer timer)
        {
            if (timer.minTimerLength > timer.maxTimerLength) {
                if (timer.minTimerLength != timer.oldMinTimer) {
                    timer.maxTimerLength = timer.minTimerLength; //min moved, move max up to min
                }
                else {
                    timer.minTimerLength = timer.maxTimerLength; //max moved, move min down to max
                }
                UpdateOldTimerLengths(timer);
            }
        }
        private void UpdateOldTimerLengths(IntervalTimer timer)
        {
            timer.oldMinTimer = timer.minTimerLength;
        }
    }
}
