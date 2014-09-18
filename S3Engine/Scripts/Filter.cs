using System;
using System.Collections.Generic;
using UnityEngine;


namespace S3Engine
{
    public class Filter : MonoBehaviour
    {
        public State belong;
        public State target;
        public List<SignalCondition> conditions;
        public bool watchBelong;

        void Update()
        {
            if (watchBelong && belong != null && !belong.Activated) return;
            foreach (var sc in conditions)
            {
                if (!sc.Satisfied()) return;
            }
            belong.Activated = false;
            target.Activated = true;
        }
    }
}
