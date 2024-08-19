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
    public static Vector3 OneKiloVolumeScale = new Vector3(.65f, .7f, .65f);
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

    public static Vector3 ScaleWeightByVolume(float targetVolume)
    {
        /*return new Vector3(
                            Mathf.Pow(targetVolume, 1 / 3) * OneKiloVolumeScale.x, 
                            Mathf.Pow(targetVolume, 1 / 3) * (OneKiloVolumeScale.y * 2),
                            Mathf.Pow(targetVolume, 1 / 3) * OneKiloVolumeScale.z
                          );*/
        //return OneKiloVolumeScale * (targetVolume * .75f);
        return Vector3.one * targetVolume * .95f;
    }

    // max radius: 4.5
    // max height: 15

    #endregion
}
