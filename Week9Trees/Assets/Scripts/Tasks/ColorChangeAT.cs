using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ColorChangeAT : ActionTask {

		public BBParameter<Renderer> rendererBBP;
		public Color color = Color.white;
		public bool randomColor = false;

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			if (randomColor) {

                rendererBBP.value.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

			}
			else
			{

                rendererBBP.value.material.color = color;

            }				

            EndAction(true);

		}

	}

}