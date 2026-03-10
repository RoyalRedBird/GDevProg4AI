using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class ProxColChangeAT : ActionTask {

		public BBParameter<Transform> targetBBP;
		public BBParameter<Renderer> rendererBBP;
		public BBParameter<float> proximityBBP;

		public Color targetColor;
		private Color currentColor;

        protected override void OnExecute()
        {

            currentColor = rendererBBP.value.material.color;

        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			float intrpolant = 1 - Vector3.Distance(targetBBP.value.position, agent.transform.position) / proximityBBP.value;

			Color colorStep = Color.Lerp(currentColor, targetColor, intrpolant);
			rendererBBP.value.material.color = colorStep;

		}

        protected override void OnStop()
        {

            rendererBBP.value.material.color = currentColor;

        }

	}
}