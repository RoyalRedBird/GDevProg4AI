using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class RefreshWaypoint : ActionTask {

		public BBParameter<GameObject> waypoint;
		public Blackboard myBlackboard;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {

			myBlackboard = agent.gameObject.GetComponent<Blackboard>();

			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			Vector3 newWayPos = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
			waypoint.value.transform.position = newWayPos;

			int currentWPHits = myBlackboard.GetVariableValue<int>("waypointsHit");
			Debug.Log($"Current WPs hit: {currentWPHits}");


            myBlackboard.SetVariableValue("waypointsHit", currentWPHits + 1);

			EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}