using System;
using System.Collections.Generic;
using UnityEngine;

namespace S3Engine.Relationship
{
    public class ChainSignal : MonoBehaviour
    {
        public State belonged;
        public SignalPath[] signalPathes;
        public Signal target;
        void Update()
        {
            if (belonged != null && !belonged.Activated) return;
            foreach (var sp in signalPathes)
            {
                if (sp.Pathed())
                {
                    target.On();
                }
            }
        }
        
    }
}
