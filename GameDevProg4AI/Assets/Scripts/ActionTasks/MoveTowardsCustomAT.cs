using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

    [Description("Modified Move Toward script for moving from interactable to interactable.")]
    public class MoveTowardsCustomAT : ActionTask<Transform>
    {

        [RequiredField]
        private GameObject target;
        public BBParameter<float> speed = 2;
        public BBParameter<float> stopDistance = 0.1f;
        public bool waitActionFinish;

        RoombaManagerScript roombaScript;

        protected override string OnInit()
        {

            roombaScript = agent.GetComponent<RoombaManagerScript>();
            return null;

        }

        protected override void OnExecute()
        {

            int placeholderIndex = roombaScript.currentIndex;

            placeholderIndex++;

            if(placeholderIndex > roombaScript.objArrayMaxIndex)
            {

                placeholderIndex = 0;

            }

            roombaScript.currentIndex = placeholderIndex;

            target = roombaScript.objectArray[placeholderIndex];

        }

        protected override void OnUpdate()
        {
            if ((agent.position - target.transform.position).magnitude <= stopDistance.value)
            {
                EndAction();
                return;
            }

            agent.position = Vector3.MoveTowards(agent.position, target.transform.position, speed.value * Time.deltaTime);
            if (!waitActionFinish)
            {
                EndAction();
            }
        }
    }
}