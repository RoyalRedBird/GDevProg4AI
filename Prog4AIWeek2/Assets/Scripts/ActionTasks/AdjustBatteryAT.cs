using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class AdjustBatteryAT : ActionTask {

        //private Blackboard agentBlackboard;
        public float adjustValue;
        public BBParameter<float> currentCharge = 100;

        protected override string OnInit() {

            /*agentBlackboard = agent.GetComponent<Blackboard>();

            if (agentBlackboard != null)
            {

                return null;

            }
            else
            {

                return $"AdjustBatteryAT - {agent.name}: Unable to get blackboard reference!";

            }*/

            return null;

        }

		protected override void OnUpdate() {

            currentCharge.value += adjustValue * Time.deltaTime;

		}

	}

}