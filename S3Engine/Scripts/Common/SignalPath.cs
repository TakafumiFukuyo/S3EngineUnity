using System;
using System.Collections.Generic;
using UnityEngine;

namespace S3Engine
{
    [Serializable]
    public class SignalPath
    {
        public Signal[] signals;

        public bool Pathed()
        {
            foreach (var s in signals)
            {
                if (!s.Read())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
