using UnityEngine;

public class InteractCubeOneScript : Interactable
{

    bool toggleOn = false;

    public Color offColor;
    public Color onColor;

    private Material objMaterial;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        objMaterial = GetComponent<MeshRenderer>().material;

    }

    // Update is called once per frame
    void Update()
    {

        if (toggleOn)
        {

            objMaterial.color = onColor;

        }
        else
        {

            objMaterial.color = offColor;

        }
        
    }

    public override void Interact()
    {
        
        toggleOn = !toggleOn;

    }


}
