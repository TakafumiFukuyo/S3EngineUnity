using UnityEngine;
using System.Collections.Generic;

namespace S3Engine
{
    public class Slot : MonoBehaviour
    {
        public State first;

        void Awake()
        {
            first.Activated = true;
        }
    }
}