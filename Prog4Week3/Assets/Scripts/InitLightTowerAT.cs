using UnityEngine;
using NodeCanvas.Framework;

namespace NodeCanvas.Tasks.Actions
{

    public class InitLightTowerAT : ActionTask
    {

        public BBParameter<Light> lightBBP;
        public BBParameter<Transform> workpadBBP;
        public string workPadName;

        protected override string OnInit()
        {
            
            lightBBP.value = agent.GetComponentInChildren<Light>();
            workpadBBP.value = agent.transform.Find(workPadName);

            if (lightBBP != null && workpadBBP != null) return null;
                else return $"InitLightTowerAT in {agent.name}: Unable to find all references!";           

        }

    }

}


