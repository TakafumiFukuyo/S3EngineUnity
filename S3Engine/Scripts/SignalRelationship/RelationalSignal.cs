using System;
using System.Collections.Generic;
using UnityEngine;

namespace S3Engine.Relationship
{
    public class RelationalSignal : MonoBehaviour
    {
        public State belonged;
        public List<SignalCondition> conditions;
        public List<SignalCondition> targetConditions;


        void Update()
        {
            if (belonged != null && !belonged.Activated) return;
            foreach (var sc in conditions)
            {
                if (!sc.Satisfied()) return;
            }
            foreach (var sc in targetConditions)
            {
                sc.signal.Set(sc.condition);
            }
        }
    }
}