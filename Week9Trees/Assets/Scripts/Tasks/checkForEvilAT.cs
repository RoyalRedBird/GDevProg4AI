using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class checkForEvilAT : ActionTask {

		public BBParameter<GameObject> evilCreatureBBP;
		public BBParameter<float> evilRadiusBBP;
		//public BBParameter<Transform> activeWaypointBBP;

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override void OnUpdate() {

			if(Vector3.Distance(evilCreatureBBP.value.transform.position, agent.transform.position) <= evilRadiusBBP.value)
			{

				EndAction(false);

			}
			else {

                EndAction(true);

            }
		
		}

	}

}