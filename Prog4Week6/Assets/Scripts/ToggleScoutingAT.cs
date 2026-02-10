using UnityEngine;
using NodeCanvas.Framework;

public class ToggleScoutingAT : ActionTask
{
    
    public BBParameter<bool> scoutingBBP;
    public AudioSource audioSource;
    public AudioClip clip;

    protected override void OnExecute()
    {

        scoutingBBP.value = !scoutingBBP.value;

        AudioManager.Instance.PlaySoundEffect(clip, audioSource);

        EndAction(true);

    }

}
