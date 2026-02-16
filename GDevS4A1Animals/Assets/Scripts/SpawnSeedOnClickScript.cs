using UnityEngine;

public class SpawnSeedOnClickScript : MonoBehaviour
{

    [SerializeField] private GameObject seedObject;
    [SerializeField] private GameObject worldCursor;
    [SerializeField] private LayerMask groundLayer;
    private Vector3 worldPosOfMouse;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePos = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, groundLayer))
        {

            worldPosOfMouse = hit.point;

        }

        worldCursor.transform.position = worldPosOfMouse;

        if (Input.GetMouseButtonDown(0))
        {

            SpawnSeedAtClickedPos();

        }
        
    }

    private void SpawnSeedAtClickedPos()
    {

        GameObject newSeed = GameObject.Instantiate(seedObject);

        newSeed.transform.position = worldPosOfMouse;

    }

}
