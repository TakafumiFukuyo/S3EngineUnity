using UnityEngine;
using System.Collections.Generic;

namespace S3Engine
{
    public class Signal : MonoBehaviour
    {
        public List<MonoBehaviour> onTs;
        private List<IOnT> inOnTs = new List<IOnT>();
        public List<MonoBehaviour> onFs;
        private List<IOnF> inOnFs = new List<IOnF>();
        [SerializeField]
        private bool state;
#if UNITY_EDITOR
        public bool changeTo;
        public bool changeSwitch;
#endif
        public void On()
        {
            state = true;
            foreach (var iont in inOnTs)
            {
                iont.OnT();
            }
        }

        public void Off()
        {
            state = false;
            foreach (var ionf in inOnFs)
            {
                ionf.OnF();
            }
        }

        public void Set(bool state)
        {
            if (state)
            {
                On();
            }
            else
            {
                Off();
            }
        }

        public bool Read()
        {
            return state;
        }

        public bool DestructiveRead(bool state)
        {
            bool copy = this.state;
            this.state = state;
            return copy;
        }

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

        void Update()
        {
#if UNITY_EDITOR
            if (changeSwitch)
            {
                Set(changeTo);
                changeSwitch = false;
            }
#endif
        }
    }
}