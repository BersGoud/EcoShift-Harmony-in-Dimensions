using System;
using UnityEngine;
using UnityEngine.UI;
using BG_Level.PowerSystem;

namespace BG_Level.PowerSystem
{

	public class Machine : MonoBehaviour
	{
		public string ID;
		public PowerSystem powerSystem;

		[DisplayWithoutEdit]
		public bool on;

        public GameObject EndingPanel;
        public Material onMat;
		public Material offMat;

		public Cable connectedCable;

		[HideInInspector] public MeshRenderer meshRenderer;

		public void OnStart()
		{
			meshRenderer = GetComponent<MeshRenderer>();
			ID = Guid.NewGuid().ToString();
		}

		public void ChangeOnState(bool state)
		{
			on = state;

			powerSystem.CheckSystemDetails();
		}

		private void Update()
		{
			if (on && powerSystem.hasPower)
			{
                meshRenderer.material = onMat;
                Canvas canvas = EndingPanel.GetComponent<Canvas>();
				canvas.enabled = true;
				Debug.Log("Test canvas" +canvas);
            }
            else
				meshRenderer.material = offMat;
		}
	}

}