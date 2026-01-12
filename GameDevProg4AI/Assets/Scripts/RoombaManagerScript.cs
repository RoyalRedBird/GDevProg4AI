using UnityEngine;

public class RoombaManagerScript : MonoBehaviour
{

    public GameObject[] objectArray;

    public int objArrayMaxIndex;
    public int currentIndex = 0;

    public float maxInteractRange = 1;

    public Color currentColor;

    public Material roombaMaterial;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        objArrayMaxIndex = objectArray.Length - 1;
        roombaMaterial = GetComponent<MeshRenderer>().material;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InteractTargetObject()
    {

        if (objectArray[currentIndex].GetComponent<Interactable>())
        {

            objectArray[currentIndex].GetComponent<Interactable>().Interact();

        }

    }

    public void UpdateColor()
    {

        Debug.Log("Changing color.");
        currentColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);

        roombaMaterial.color = currentColor;

    }

}
