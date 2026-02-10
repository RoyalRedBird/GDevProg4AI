using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class SetDestinationManualAT : ActionTask {

        public BBParameter<Vector3> targetPositionBBP;
        public BBParameter<GameObject> targetSeedPileBBP;


        protected override void OnUpdate()
        {

            targetPositionBBP.value = targetSeedPileBBP.value.transform.position;

        }

    }
}