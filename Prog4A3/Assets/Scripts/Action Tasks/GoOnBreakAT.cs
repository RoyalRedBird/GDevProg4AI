using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{

    public class GoOnBreakAT : ActionTask
    {

        public BBParameter<float> breakTimeBB;
        public Blackboard myBlackboard;
        public Color breakColor;

        public Color currentColor;

        public Material blockMat;

        protected override void OnExecute()
        {

            blockMat = agent.GetComponent<MeshRenderer>().material;

            Debug.Log("Going on break!");
            blockMat.color = breakColor;

        }

        protected override void OnUpdate()
        {

            breakTimeBB.value -= Time.deltaTime;

        }

    }

}


