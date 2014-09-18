using System;
using System.Collections.Generic;
using UnityEngine;

namespace S3Engine
{
    [Serializable]
    public class SignalCondition
    {
        [SerializeField]
        public Signal signal;
        [SerializeField]
        public bool condition;

        public bool Satisfied()
        {
            return signal.Read() == condition;
        }
    }
}