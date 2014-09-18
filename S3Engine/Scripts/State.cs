using UnityEngine;
using System.Collections.Generic;

namespace S3Engine
{
    public class State : MonoBehaviour
    {
        public List<MonoBehaviour> onTs;
        private List<IOnT> inOnTs = new List<IOnT>();
        public List<MonoBehaviour> onFs;
        private List<IOnF> inOnFs = new List<IOnF>();
        private bool activated;

        void Start()
        {
            foreach (var obj in onTs)
            {
                if (obj is IOnT)
                {
                    inOnTs.Add((IOnT)obj);
                }
            }

            foreach (var obj in onFs)
            {
                if (obj is IOnF)
                {
                    inOnFs.Add((IOnF)obj);
                }
            }
        }

        public bool Activated
        {
            get
            {
                return activated;
            }
            set
            {
                if (value)
                {
                    foreach (var iont in inOnTs)
                    {
                        iont.OnT();
                    }
                }
                else
                {
                    foreach (var ionf in inOnFs)
                    {
                        ionf.OnF();
                    }
                }
                activated = value;
            }
        }
        
    }
}