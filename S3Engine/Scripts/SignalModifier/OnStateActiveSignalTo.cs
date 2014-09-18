using System;
using System.Collections.Generic;
using UnityEngine;

namespace S3Engine.Modifier
{
    public class OnStateActiveSignalTo : MonoBehaviour,IOnT
    {
        public Signal target;
        public bool value;
        public void OnT()
        {
            target.Set(value);
        }
    }
}
