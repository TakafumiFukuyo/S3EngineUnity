using UnityEngine;
using System.Collections;

namespace S3Engine.GraphicalDebug
{
    public class StateActivated : MonoBehaviour
    {
        public State viewTarget;
        public GameObject viewPrefab;
        public Vector3 positionDifference;
        public Vector3 scale = Vector3.one;
        public Vector3 eulerAngles = Vector3.zero;
        private Color onColor,offColor;
        private GraphicsSet graphicsSet;
        private GameObject view;

        void Start()
        {
            if (viewPrefab.GetComponent<GraphicsSet>() == null)
            {
                Debug.Log("ERROR: GraphicsSet is not attatched View Prefab");
                return;
            }
            view = (GameObject)Instantiate(viewPrefab);
            view.transform.parent = transform;
            view.transform.localPosition = Vector3.zero + positionDifference;
            view.transform.localEulerAngles = eulerAngles;
            view.transform.localScale = scale;
            graphicsSet = view.GetComponent<GraphicsSet>();
            onColor = graphicsSet.on.renderer.material.color;
            offColor = graphicsSet.off.renderer.material.color;
            var stateName = viewTarget.name;
            graphicsSet.textMesh.text = stateName;
        }

        void Update()
        {
            if (graphicsSet == null) return;
            if (viewTarget.Activated)
            {
                graphicsSet.on.SetActive(true);
                graphicsSet.off.SetActive(false);
                graphicsSet.textMesh.color = onColor;
            }
            else
            {
                graphicsSet.on.SetActive(false);
                graphicsSet.off.SetActive(true);
                graphicsSet.textMesh.color = offColor;
            }
        }
    }
}