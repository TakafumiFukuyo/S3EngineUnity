using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace S3Engine.Modifier
{
    public class TimerSignal : MonoBehaviour
    {
        public State belonged;
        public List<SignalCondition> conditions;
        public List<SignalCondition> targetConditions;
        public float fireTime;
        public bool repeat;
        private bool timered = false;


        IEnumerator FireTimer(float time)
        {
            yield return new WaitForSeconds(time);
            foreach (var sc in targetConditions)
            {
                sc.signal.Set(sc.condition);
            }
            if (repeat)
            {
                timered = false;
            }
        }

        void Update()
        {
            if (belonged != null && !belonged.Activated) return;
            foreach (var sc in conditions)
            {
                if (!sc.Satisfied()) return;
            }
            if (!timered)
            {
                timered = true;
                StartCoroutine(FireTimer(fireTime));
            }
        }
    }
}