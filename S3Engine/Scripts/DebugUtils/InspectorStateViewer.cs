using UnityEngine;
using System.Collections;

namespace S3Engine.DebugUtils
{
	public class InspectorStateViewer : MonoBehaviour
    {
        public State[] states;
        public bool[] statesActivated;

        void Start()
        {
            statesActivated = new bool[states.Length];
        }

        void Update()
        {
            int i = 0;
            foreach (var s in states)
            {
                statesActivated[i] = s.Activated;
                i++;
            }
        }
    }
}