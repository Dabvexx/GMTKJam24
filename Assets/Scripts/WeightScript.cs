using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// 
///</summary>
public enum ValueTypes { veryLow, low, medium, high, veryHigh }
public class WeightScript : MonoBehaviour
{
    #region Variables
    // Variables.
    // Makes sure you cant remove weights once you use a modifier
    public bool isLocked = false;
    public float weight = 1f;
    public ValueTypes type = ValueTypes.veryLow;
    #endregion

    #region Unity Methods

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    #endregion

    #region Private Methods
    // Private Methods.
    
    #endregion

    #region Public Methods
    // Public Methods.
    #endregion
}
