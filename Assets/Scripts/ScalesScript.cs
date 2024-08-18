using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

///<summary>
/// 
///</summary>

public class ScalesScript : MonoBehaviour
{
    #region Variables
    // Variables.
    [SerializeField] private GameObject scalePrefab;
    [SerializeField] private GameObject scaleTargetPrefab;
    private Dictionary<GameObject, ScaleDish> scales= new Dictionary<GameObject, ScaleDish>();
    private GameObject[] scaleTargets;
    [SerializeField] private float centerOffset;
    [SerializeField] private int scaleNum;

    #endregion

    #region Unity Methods

    void Start()
    {
        GenerateScales(scaleNum);
    }

    void Update()
    {
        foreach (var scale in scales.Values)
        {
            //Gizmos.DrawLine(scales[i].transform.position, transform.position);
            //Debug.DrawRay(scale.transform.position, (transform.position - scale.transform.position) * 2.2f);
        }

        UpdateScalePosition(scaleNum);
    }

    #endregion

    #region Private Methods
    // Private Methods.
    /// <summary>
    /// Generates the scales for either side
    /// </summary>
    /// <param name="numScales"></param>
    private void GenerateScales(int numScales)
    {
        scaleTargets = new GameObject[numScales];
        // Calculate angle between points 
        float angle = Mathf.Rad2Deg * ((2 * Mathf.PI) / numScales);
        Debug.Log($"angle for n = {scaleNum} points: {angle}");

        // Turn that angle into a vector3 around the center point
        for (int i = 0; i < numScales; i++)
        {
            Quaternion vecAngle = Quaternion.AngleAxis((angle * (i + 1)), Vector3.up);
            Vector3 result = vecAngle * Vector3.forward;
            Debug.Log($"Vector for point {i}: {result}");

            // Set scale target to be level when first spawned
            // Will be set when we spawn in permenant weights
            scaleTargets[i] = new GameObject($"Scale {i} Target");
            scaleTargets[i].transform.position = transform.position + (result * centerOffset);

            // Create scale object 
            var scale = Instantiate(scalePrefab, transform.position + (result * centerOffset), Quaternion.identity, transform);
            ScaleDish scaleDish = scale.GetComponentInChildren<ScaleDish>();
            scales.Add(scale, scaleDish);
            //scales[scale].name = $"Scale {i}";
            GeneratePermanentWeights(1, 5);
        }

        CalculateOffsetBasedOnWeight(numScales);
    }

    private void CalculateWinPositions()
    {
        // box trigger colliders that if the scale enters gets set to true and false when exit.

    }

    /// <summary>
    /// Generates the amount of weights that can no longer be moves
    /// </summary>
    /// <param name="numWeights">The amount of permanent weights on a scale</param>
    /// <param name="maxTotalWeight">The amount of weight total on a scale</param>
    /// <returns>The amount of weight on a scale that can not be moved</returns>
    /// Might change the return to have a few weights you are able to take off the gain some new weights
    private void GeneratePermanentWeights(Transform scaleLocation, int maxNumWeights, float maxTotalWeight)
    {
        int curWeights = 0;
        float curWeight = 0;

        while (maxTotalWeight < curWeight || curWeights < maxNumWeights)
        {

        }
    }

    private Vector3 RandomCirclePoint(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;

        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;

        return pos;
    }

    // This is probably gonna be very complicated
    // Influence = 100% / (num scales away + 1)
    // it would be 1 to 1 across from eachother
    // we need to average out the influences of the weights that arent in equilibrium
    // weights in equalibrium will have no influences on the weights around themselves
    // num scales away is 
    // ex: 2 scales: weight is 1:1
    // 3: influence is 1:2

    // Use these values as points to go to and lerp between then
    // Only update this when a weight updates a scale
    private void CalculateOffsetBasedOnWeight(int numScales)
    {
        // we only influence the scale directly across from us in this case
        if (numScales % 2 == 1)
        {
            for (int i = 0; i < numScales / 2; i++)
            {
                // process in pairs
                var scale1 = scales.ElementAt(i);
                var scale2 = scales.ElementAt(i + (numScales / 2));

                //find the difference between them
                float diff = scale1.Value.totalWeight - scale2.Value.totalWeight;
                diff = Mathf.Abs(diff);

                // Might make this more sophisticated than a clamp.
                // +-45 degrees is the max it should do though
                // I need to do a calculation that will bring it from an angle to a point on a circle.
                // y = k (k = 0 in this case) + radius * sin(theta) (theta being the angle)
                // At least i think.
                Mathf.Clamp(diff, -45, 45);
                float rot = centerOffset * Mathf.Sin(diff);
                Debug.Log(rot);
                // calculate 
                // whoever weighs more gets the negative value while the lighter one gets a positive value.
                // scaleone 
                if (scale1.Value.totalWeight > scale2.Value.totalWeight)
                {
                    // do something to move the target point down
                    //scale1.Key.transform.position
                    scaleTargets[i].transform.position = Vector3.down * diff;
                }
            }
            // For now we only do the 2 cases, but if we do odd numbers we will probably have to do things based off the influence they have on the scales near and far then all averaged together
        }
    }

    private void UpdateScalePosition(int numScales)
    {
        for (int i = 0; i < numScales; i++)
        {
            var scale = scales.ElementAt(i).Key;
            // Maybe make the slerp go faster with heavier weights, bigger diff.
            scale.transform.position = Vector3.Slerp(scale.transform.position, scaleTargets[i].transform.position, .2f);
        }
        //Vector3.Slerp
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for (int i = 0; i < scaleNum; i++)
        {
            //Gizmos.DrawLine(scales[i].transform.position, transform.position);
            Gizmos.DrawRay(scales[i].transform.position, (transform.position - scales[i].transform.position) * 2);
        }
    }*/
    #endregion

    #region Public Methods
    // Public Methods.

    #endregion
}
