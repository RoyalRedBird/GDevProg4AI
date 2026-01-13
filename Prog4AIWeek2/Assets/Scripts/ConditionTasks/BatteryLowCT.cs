using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Conditions {

	public class BatteryLowCT : ConditionTask {


		private Blackboard agentBlackboard;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){

            agentBlackboard = agent.GetComponent<Blackboard>();

            if (agentBlackboard != null)
            {

                return null;

            }
            else
            {

                return $"RechargeBatteryAT - {agent.name}: Unable to get blackboard reference!";

            }

        }

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			
			if(agentBlackboard.GetVariableValue<float>("currentCharge") < 50)
			{

                return true;

			}
			else
			{

				return false;

			}			
			
		}

	}

}