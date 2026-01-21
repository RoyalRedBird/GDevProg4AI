using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Actions {

	public class BoostAT : ActionTask {

		public BBParameter<float> scanRadiusBBP;
		public float BoostValue = 5;

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			scanRadiusBBP.value += BoostValue;

			EndAction(true);
		}
	}
}