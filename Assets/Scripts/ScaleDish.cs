using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// 
///</summary>
public class ScaleDish : MonoBehaviour
{
    #region Variables
    // Variables.
    [SerializeField]public float totalWeight = 0f;
    private ScalesScript ss;
    #endregion

    #region Unity Methods

    void Start()
    {
        ss = FindAnyObjectByType<ScalesScript>().GetComponent<ScalesScript>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Weight"))
        {
            Debug.Log(other.GetComponent<WeightScript>().weight);

            totalWeight += other.GetComponent<WeightScript>().weight;
            //Debug.Log(totalWeight);
            ss.CalculateOffsetBasedOnWeight();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Weight"))
        {
            totalWeight -= other.GetComponent<WeightScript>().weight;
            ss.CalculateOffsetBasedOnWeight();
        }
    }

    #endregion

    #region Private Methods
    // Private Methods.

    #endregion

    #region Public Methods
    // Public Methods.

    #endregion
}
