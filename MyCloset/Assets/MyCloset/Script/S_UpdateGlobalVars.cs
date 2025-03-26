using UnityEngine;

public class S_UpdateGlobalVars : MonoBehaviour
{
    // The name of the variable in S_GlobalVars to update
    [Tooltip("Name of the variable in S_GlobalVars to update (e.g., Garment1)")]
    public string VariableName;

    // Local value to sync with the global variable
    public bool LocalValue; // Initialize to false by default

    // Reference to S_GlobalVars
    private S_GlobalVars globalVars;

    // GameObject whose material will be monitored
    [Tooltip("The GameObject whose material changes are monitored")]
    public GameObject TargetGameObject;

    // Target material to check against
    [Tooltip("The material that determines if LocalValue is true")]
    public Material TargetMaterial;

    // Track the previous material
    private Material previousMaterial;

    // Initialize everything via SetStart
    public void SetStart()
    {
        Debug.Log("Initializing S_UpdateGlobalVars...");

        // Try to get the S_GlobalVars component from the parent object
        globalVars = transform.parent.GetComponent<S_GlobalVars>();

        // If not found on the parent, search the scene for S_GlobalVars
        if (globalVars == null)
        {
            globalVars = FindObjectOfType<S_GlobalVars>();
            if (globalVars == null)
            {
                Debug.LogError("S_GlobalVars script not found in the scene!");
            }
            else
            {
                Debug.Log("Found S_GlobalVars script in the scene.");
            }
        }

        if (TargetGameObject == null)
        {
            Debug.LogError("TargetGameObject is not assigned! Please assign it in the Inspector.");
            return;
        }

        // Cache the initial material of the TargetGameObject
        Renderer targetRenderer = TargetGameObject.GetComponent<Renderer>();
        if (targetRenderer != null)
        {
            previousMaterial = targetRenderer.sharedMaterial;
        }
        else
        {
            Debug.LogError("TargetGameObject does not have a Renderer component!");
        }
    }

    void Update()
    {
        if (TargetGameObject == null) return;

        // Continuously check if the material on TargetGameObject has changed
        Renderer targetRenderer = TargetGameObject.GetComponent<Renderer>();
        if (targetRenderer != null && targetRenderer.sharedMaterial != previousMaterial)
        {
            // Material has changed
            previousMaterial = targetRenderer.sharedMaterial;
            CheckMaterialAndSetVariable();
        }
    }

    private void CheckMaterialAndSetVariable()
    {
        // Determine LocalValue based on the current material
        Renderer targetRenderer = TargetGameObject.GetComponent<Renderer>();
        if (targetRenderer != null)
        {
            Debug.Log($"Current Material: {targetRenderer.sharedMaterial.name}, Target Material: {TargetMaterial.name}");
            
            if (targetRenderer.sharedMaterial == TargetMaterial)
            {
                LocalValue = true;
                Debug.Log("now it is TRUEEEEE");
            }
            else
            {
                LocalValue = false;
                Debug.Log("now it is FALSEEEEEE");
            }
        }

        UpdateGlobalVariable(); // Update the global variable with the new value
    }

    private void UpdateGlobalVariable()
    {
        if (globalVars == null)
        {
            Debug.LogError("globalVars is null! Ensure S_GlobalVars is attached to the parent GameObject or is found in the scene.");
            return;
        }

        if (string.IsNullOrEmpty(VariableName))
        {
            Debug.LogError("VariableName is not assigned or is empty!");
            return;
        }

        // Use reflection to dynamically update the global variable
        var field = globalVars.GetType().GetField(VariableName);

        if (field != null && field.FieldType == typeof(bool))
        {
            field.SetValue(globalVars, LocalValue); // Update the global variable
            Debug.Log($"{VariableName} in S_GlobalVars updated to {LocalValue}");
        }
        else
        {
            Debug.LogError($"Variable '{VariableName}' not found or is not of type bool in S_GlobalVars.");
        }
    }
}
