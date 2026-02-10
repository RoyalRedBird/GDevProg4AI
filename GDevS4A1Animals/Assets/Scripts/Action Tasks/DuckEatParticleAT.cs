using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class DuckEatParticleAT : ActionTask {

		public BBParameter<GameObject> seedPileBBP;

		//Called once per frame while the action is active.
		protected override void OnUpdate() {


			seedPileBBP.value.GetComponent<SeedPileScript>().EatSeeds();

		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}