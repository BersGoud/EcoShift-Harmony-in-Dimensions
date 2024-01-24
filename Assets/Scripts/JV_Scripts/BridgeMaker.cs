using Assets.Scripts.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;

public class BridgeMaker : Interaction
{
    public ThirdPersonController Player;
    public Transform point1;
    public Transform point2;
    public Transform parent;
    private GameObject cylinder;
    public Material cylinderMaterial;
    public Material completed;
    private Renderer rend;
    private bool buttonclicked;
    CableGamemanager gameManager = CableGamemanager.Instance;
    public override string Interact()
    {
        // Code for interaction(currently dissabled)
        buttonclicked = true;
        gameManager.StartMiniGame("Level_JV_2");
        Player.CameraMovementEnabled = false;
        return base.Interact();
    }
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
        //Get positions of the start and end of the bridge
        Vector3 point1Position = point1.position + new Vector3(0.48f, 0, -0.95f);
        Vector3 point2Position = point2.position + new Vector3(-0.48f, 0, -0.95f);
        // Calculate the position and rotation of the bridge
        Vector3 midpoint = (point1Position + point2Position) / 2f;
        Quaternion rotation = Quaternion.LookRotation(point2Position - point1Position);
        rotation *= Quaternion.Euler(90f, 0f, 0f);
        float distance = Vector3.Distance(point1Position, point2Position);

        // Create the bridge
        GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinder.transform.position = midpoint;
        cylinder.transform.rotation = rotation;
        cylinder.transform.localScale = new Vector3(1f, distance / 2f, 1f);

        // Set the parent of the bridge
        if (parent != null)
        {
            cylinder.transform.parent = parent;
        }
        // Apply the texture to the bridge
        Renderer cylinderRenderer = cylinder.GetComponent<Renderer>();
        if (cylinderRenderer != null)
        {
            cylinderRenderer.material = cylinderMaterial;
        }
    }
    void DeleteCylinder()
    {
        // Destroy the bridge if necessary
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
            if (Physics.Raycast(ray, out hit,10f) && hit.collider.gameObject == gameObject)
            {
                // Cube is clicked
                buttonclicked = true;
                // Start the minigame
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
            // Check if the minigame is completed
            if (gameManager.IsMiniGameCompleted())
            {
                // Create the bridge and continue the game
                SpawnObject();
                rend = GetComponent<Renderer>();
                rend.material = completed;
                Player.CameraMovementEnabled = true;
                buttonclicked = false;
            }
        }
    }
}
