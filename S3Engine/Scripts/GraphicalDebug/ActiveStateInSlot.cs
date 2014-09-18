using System;
using UnityEngine;
using System.Collections;


namespace S3Engine.GraphicalDebug
{
    public class ActiveStateInSlot: MonoBehaviour
    {
        public State[] viewTargets;
        public GameObject[] viewPrefabs;
        public Vector3 positionDifference;
        public Vector3 scale = Vector3.one;
        public Vector3 eulerAngles = Vector3.zero;
        private GameObject[] views;

        void Start()
        {
            if (viewTargets.Length != viewPrefabs.Length)
            {
                Debug.Log("ERROR: View Prefabs is must same the number View Targets");
                return;
            }
            views = new GameObject[viewTargets.Length];
            for (int i = 0; i < viewTargets.Length; i++)
            {
                var vp = (GameObject)Instantiate(viewPrefabs[i]);
                var tm = vp.GetComponent<TextMesh>();
                if (tm != null)
                {
                    tm.text = viewTargets[i].name;
                }
                vp.transform.parent = transform;
                vp.transform.localPosition = Vector3.zero + positionDifference;
                vp.transform.localEulerAngles = eulerAngles;
                vp.transform.localScale = scale;
                views[i] = vp;
                vp.SetActive(false);
            }
        }

        void Update()
        {
            if (views == null) return;
            for (int i = 0; i < views.Length; i++)
            {
                if (viewTargets[i].Activated)
                {
                    foreach (var v in views)
                    {
                        v.SetActive(false);
                    }
                    views[i].SetActive(true);
                }
            }
        }
    }
}
