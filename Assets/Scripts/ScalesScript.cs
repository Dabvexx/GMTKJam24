using System.Collections.Generic;
using System.Linq;
using UnityEngine;

///<summary>
///
///</summary>

public class ScalesScript : MonoBehaviour
{
    #region Variables

    // Variables.
    [SerializeField] private GameObject scalePrefab;

    private Dictionary<GameObject, ScaleDish> scales = new Dictionary<GameObject, ScaleDish>();
    private Vector3[] pivots;
    private float[] pivotAmounts;
    private float[] currentRotation;

    [SerializeField] private float centerOffset;
    [SerializeField] private float baseSpeed = 35;

    //[SerializeField] private float speed = 1f;
    [SerializeField] private int scaleNum;

    private float scaleAngle;

    #endregion Variables

    #region Unity Methods

    private void Start()
    {
        GenerateScales(scaleNum);
    }

    private void Update()
    {
        foreach (var scale in scales.Values)
        {
            //Gizmos.DrawLine(scales[i].transform.position, transform.position);
            //Debug.DrawRay(scale.transform.position, (transform.position - scale.transform.position) * 2.2f);
        }
        UpdateScalePosition();
    }

    #endregion Unity Methods

    #region Private Methods

    // Private Methods.
    /// <summary>
    /// Generates the scales for either side
    /// </summary>
    /// <param name="numScales"></param>
    private void GenerateScales(int numScales)
    {
        pivots = new Vector3[numScales];
        pivotAmounts = new float[numScales / 2];
        currentRotation = new float[numScales / 2];

        // Calculate angle between points
        scaleAngle = Mathf.Rad2Deg * ((2 * Mathf.PI) / numScales);
        Debug.Log($"angle for n = {scaleNum} points: {scaleAngle}");

        // Turn that angle into a vector3 around the center point
        for (int i = 0; i < numScales; i++)
        {
            Quaternion vecAngle = Quaternion.AngleAxis((scaleAngle * (i + 1)), Vector3.up);
            Vector3 result = (vecAngle * Vector3.forward) * centerOffset;
            //Debug.Log($"Vector for point {i}: {result}");

            // Get the angle along the axis with the cross product
            pivots[i] = Vector3.Cross(Vector3.Cross(vecAngle.eulerAngles, Vector3.forward), Vector3.up);

            // Create scale object
            var scale = Instantiate(scalePrefab, transform.position + result, vecAngle, transform);
            ScaleDish scaleDish = scale.GetComponentInChildren<ScaleDish>();
            scales.Add(scale, scaleDish);
            //scales[scale].name = $"Scale {i}";
            GeneratePermanentWeights(scale.transform, 1, 5);
        }

        //CalculateOffsetBasedOnWeight();
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
    /// this should be changed to weighing out an item or gold coins from a customer
    private void GeneratePermanentWeights(Transform scaleLocation, int maxNumWeights, float maxTotalWeight)
    {
        int curWeights = 0;
        float curWeight = 0;

        //while (maxTotalWeight < curWeight || curWeights < maxNumWeights)
        //{
        //    Vector3 pos = RandomCirclePoint(scaleLocation.transform.position, 1);
        //    Quaternion rot = Quaternion.FromToRotation(Vector3.forward, scaleLocation.transform.position - pos);
        // Instantiate the object being paid for
        //Instantiate
        //}
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

    private void UpdateScalePosition()
    {
        if (currentRotation == null || pivotAmounts == null)
            return;

        /*for (int i = 0; i < pivotAmounts.Length; i++)
        {
            //if (pivotAmounts[i] > pivotAmountsDone[i])
            //{
            Debug.Log($"We rotatin: {currentRotation[i]}: {pivotAmounts[i]}");
            //var speed =
            // clamp between a
            if (currentRotation[i] == 0)
            {
                transform.Rotate(pivots[i], pivotAmounts[i]);
                currentRotation[i] += Mathf.Sign(pivotAmounts[i]);
                continue;
            }
            float maxrot = Mathf.Clamp(30 * pivotAmounts[i], currentRotation[i] / -30f - 1f, currentRotation[i] / 30f - 1f);
            transform.Rotate(pivots[i], maxrot);
            currentRotation[i] += Mathf.Sign(pivotAmounts[i]);
            //}
            // Maybe make the slerp go faster with heavier weights, bigger diff.
            //scale.transform.position = Vector3.Slerp(scale.transform.position, scaleTargets[i].transform.position, .1f);
        }*/

        float speed = baseSpeed;


        for (int i = 0; i < pivotAmounts.Length; i++)
        {
            float anglestep = speed * Time.deltaTime;

            //if (!Mathf.Approximately(pivotAmounts[i], 0))
            //{
                if (pivotAmounts[i] <= 0)
                {
                    anglestep *= -1;
                    if (currentRotation[i] + anglestep <= pivotAmounts[i])
                    {
                        anglestep = pivotAmounts[i] - currentRotation[i];
                    }
                }
                else
                {
                    if (currentRotation[i] + anglestep >= pivotAmounts[i])
                    {
                        anglestep = pivotAmounts[i] - currentRotation[i];
                    }
                }
            //}
            //Debug.Log(anglestep);
            //Debug.Log(pivotAmounts[i]);

            transform.Rotate(pivots[i], anglestep);

            currentRotation[i] += anglestep;
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

    private float CalculateDifferenceInWeight(float scale1, float scale2)
    {
        // Take the diff and return a value between 0 and 1
        // Calculation should return the same every time
        // if weight is double the weight of other side it should return 1.
        if (scale1 == scale2)
        {
            return 0;
        }

        // bigger divide by smaller to get the number between them
        // take that number and

        float bigger = scale1 > scale2 ? scale1 : scale2;
        float smaller = scale1 > scale2 ? scale2 : scale1;
        Debug.Log($"Bigger: {bigger}");
        Debug.Log($"Smaller: {smaller}");
        float minTilt = bigger / 2;
        float smallDif = smaller - minTilt;
        if (Mathf.Sign(smallDif) == -1)
        {
            Debug.Log("Too much diff");
            // Too much diff
            return 1;
        }

        float diff = smallDif / minTilt;

        Debug.Log($"Diff: {diff}");

        Mathf.Clamp01(diff);
        return diff;//diff3;
    }

    #endregion Private Methods

    #region Public Methods

    // Public Methods.

    // Use these values as points to go to and lerp between then
    // Only update this when a weight updates a scale
    public void CalculateOffsetBasedOnWeight()
    {
        // Slows down gameplay in some instance but it makes the system not break
        // Dont have time for a more elegant solution
        /*for (int i = 0; i < pivotAmounts.Length; i++)
        {
            if (pivotAmounts[i] > currentRotation[i])
                return;
        }*/
        // we only influence the scale directly across from us in this case
        if (scaleNum % 2 == 0)
        {
            for (int i = 0; i < scaleNum / 2; i++)
            {
                // process in pairs
                var scale1 = scales.ElementAt(i);
                var scale2 = scales.ElementAt(i + (scaleNum / 2));

                float diff = CalculateDifferenceInWeight(scale1.Value.totalWeight, scale2.Value.totalWeight);

                // whoever weighs more gets the negative value while the lighter one gets a positive value.
                if (diff <= 0)
                {
                    pivotAmounts[i] = 0f;
                    continue;
                }

                // We could get the sign using the sign of diff but i dont have time rn and im going insane
                if (scale1.Value.totalWeight > scale2.Value.totalWeight)
                {
                    pivotAmounts[i] = 30 * -diff;
                }
                else
                {
                    pivotAmounts[i] = 30 * diff;
                }
            }
            // For now we only do the 2 cases, but if we do odd numbers we will probably have to do things based off the influence they have on the scales near and far then all averaged together
        }
    }

    #endregion Public Methods
}