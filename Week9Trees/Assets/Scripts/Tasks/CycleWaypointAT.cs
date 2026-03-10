using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class CycleWaypointAT : ActionTask {

        public BBParameter<Transform> activeWaypointBBP;
        public BBParameter<Transform> waypointOneBBP;
        public BBParameter<Transform> waypointTwoBBP;

        //This is called once each time the task is enabled.
        //Call EndAction() to mark the action as finished, either in success or failure.
        //EndAction can be called from anywhere.
        protected override void OnExecute() {

            if(activeWaypointBBP.value == waypointOneBBP.value)
            {

                activeWaypointBBP.value = waypointTwoBBP.value;

            }
            else if(activeWaypointBBP.value == waypointTwoBBP.value)
            {

                activeWaypointBBP.value = waypointOneBBP.value;

            }

            EndAction(true);

		}

	}

}