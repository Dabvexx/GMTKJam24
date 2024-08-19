using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// 
///</summary>
public class ShopManager : MonoBehaviour
{
    #region Variables
    // Variables.
    public static int gold = 0;

    #endregion

    #region Unity Methods

    void Start()
    {
        SpawnBox(new float[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });
    }

    void Update()
    {
        
    }

    #endregion

    #region Private Methods
    // Private Methods.
    private bool TrySpawnInArea(Vector3 center, float width, float height, float weight)
    {
        // Calculate the radius using weight
        // if 
        // use weight to act as bounding boxes, try a few times to spawn the weight before trying to change the volume calculation to increasing radius and height equally then height more than readius before giving up and returning false.
        return false;
    }
    #endregion

    #region Public Methods
    // Public Methods.
    // Generate the weight sizes first
    public void SpawnBox(float[] weights)
    {
        // Can only fit 8 max size weights

        //if (TrySpawnInArea())
        //{
        //}
        for (int i = 0; i < weights.Length; i++)
        {
            Debug.Log($"vector of scale for weight {weights[i]}: {WeightVolumeManager.ScaleWeightByVolume(weights[i])}");
        }
    }
    #endregion
}
