using UnityEngine;
using System.Collections;

namespace S3Engine.Relationship
{
    public class LinkSignal : MonoBehaviour
    {
        public State belonged;
        public Signal source;
        public Signal target;

        void Update()
        {
            if (belonged != null && !belonged.Activated) return;
            target.Set(source.Read());
        }
    }
}