using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;

public class BridgeMaker : MonoBehaviour
{
    public ThirdPersonController Player;
    public Transform point1;
    public Transform point2;
    public Transform parent;
    private GameObject cylinder;
    public Material cylinderMaterial;
    private bool buttonclicked;
    CableGamemanager gameManager = CableGamemanager.Instance;
    private void OnEnable()
    {
        // Subscribe to the sceneUnloaded event
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable()
    {
        // Unsubscribe from the sceneUnloaded event
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }
    public void SpawnObject()
    {
        Vector3 point1Position = point1.position + new Vector3(0.48f, 0, -0.95f);
        Vector3 point2Position = point2.position + new Vector3(-0.48f, 0, -0.95f);
        // Calculate the position and rotation of the cylinder
        Vector3 midpoint = (point1Position + point2Position) / 2f;
        Quaternion rotation = Quaternion.LookRotation(point2Position - point1Position);
        rotation *= Quaternion.Euler(90f, 0f, 0f);
        float distance = Vector3.Distance(point1Position, point2Position);

        // Create the cylinder
        GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinder.transform.position = midpoint;
        cylinder.transform.rotation = rotation;
        cylinder.transform.localScale = new Vector3(1f, distance / 2f, 1f);

        // Set the parent of the cylinder
        if (parent != null)
        {
            cylinder.transform.parent = parent;
        }
        // Apply the texture to the cylinder
        Renderer cylinderRenderer = cylinder.GetComponent<Renderer>();
        if (cylinderRenderer != null)
        {
            cylinderRenderer.material = cylinderMaterial;
        }
    }
    void DeleteCylinder()
    {
        if (cylinder != null)
        {
            Destroy(cylinder);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            // Cast a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits the cube
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                // Cube is clicked
                buttonclicked = true;
                gameManager.StartMiniGame("Level_JV_2");
                Player.CameraMovementEnabled = false;
            }
        }
    }
    private void OnSceneUnloaded(Scene scene)
    {
        Debug.Log(scene.name);
        // Check if the unloaded scene is the minigame scene
        if (scene.name == "Level_JV" && buttonclicked)
        {
            // Trigger your code here, e.g., check GameManager and activate something
            if (gameManager.IsMiniGameCompleted())
            {
                // Activate your code here
                SpawnObject();
                Player.CameraMovementEnabled = true;
                buttonclicked = false;
            }
        }
    }
}
