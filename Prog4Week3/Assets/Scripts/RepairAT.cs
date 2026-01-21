using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{

    public class RepairAT : ActionTask
    {

        public BBParameter<Transform> lightTowerTargetBBP;
        public BBParameter<float> scanRadiusBBP;
        public BBParameter<float> initialRadiusBBP;

        public float repairRate = 25f;
        public float fullyRepairedThreshold = 100f;

        private Blackboard lightTowerBB;
        private float towerRepairValue;

        protected override void OnExecute()
        {
            
            lightTowerBB = lightTowerTargetBBP.value.GetComponentInParent<Blackboard>();
            towerRepairValue = lightTowerBB.GetVariableValue<float>("repairValue");

            lightTowerTargetBBP.value = null;
            scanRadiusBBP.value = initialRadiusBBP.value;

        }

        protected override void OnUpdate() {

            towerRepairValue += repairRate * Time.deltaTime;
            lightTowerBB.SetVariableValue("repairValue", towerRepairValue);

            if(towerRepairValue > fullyRepairedThreshold)
            {

                EndAction(true);

            }
        
        }

    }

}
