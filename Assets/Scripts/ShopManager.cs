using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

///<summary>
/// 
///</summary>
public class ShopManager : MonoBehaviour
{
    #region Variables
    // Variables.
    public static int gold = 0;
    [SerializeField] private GameObject boxPrefab;
    [SerializeField] private GameObject weightPrefab;

    #endregion

    #region Unity Methods

    void Start()
    {
        //SpawnBox(new float[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });
    }

    void Update()
    {
        
    }

    #endregion

    #region Private Methods
    // Private Methods.
    private bool TrySpawnInArea(GameObject SpawnPlane, float weight)
    {
        // Calculate the radius using weight
        // if 
        // use weight to act as bounding boxes, try a few times to spawn the weight before trying to change the volume calculation to increasing radius and height equally then height more than readius before giving up and returning false.
        //Ray ray = new Ray(Random.Range(,),Vector3.down);
        //if (Physics.Raycast())
        //{

        //}
        return false;
    }
    #endregion

    #region Public Methods
    // Public Methods.
    // Generate the weight sizes first
    public void SpawnBox(float[] weights)
    {
        // Can only fit 8 max size weights
        
        // Spawn box.
        var box = Instantiate(boxPrefab);

        //if (TrySpawnInArea())
        //{
        //}
        for (int i = 0; i < weights.Length; i++)
        {
            Debug.Log($"vector of scale for weight {weights[i]}: {WeightVolumeManager.ScaleWeightByVolume(weights[i])}");
        }
    }

    private Vector3 RandomCirclePoint(Vector3 center, float radius, float excludeRadius)
    {
        float ang = Random.value * 360;
        Vector3 pos;

        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;

        return pos;
    }

    private void ShowShopMenu()
    {
         
    }
    #endregion
}
