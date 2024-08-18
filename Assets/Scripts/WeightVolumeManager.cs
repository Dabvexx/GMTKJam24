using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// 
///</summary>
public static class WeightVolumeManager
{
    #region Variables
    // Variables.
    
    #endregion

    #region Private Methods
    // Private Methods.
    
    #endregion

    #region Public Methods
    // Public Methods.
    
    public static float FindWeightRadius(float volume, float height)
    {
        return Mathf.Sqrt(volume / (Mathf.PI * height));
    }

    public static float FindWeightHeight(float volume, float radius)
    {
        return volume / (Mathf.PI * Mathf.Pow(radius, 2));
    }
    public static float FindWeightVolume(float height, float radius)
    {
        return Mathf.PI * Mathf.Pow(radius, 2) * height;
    }

    // max radius: 4.5
    // max height: 15

    #endregion
}
