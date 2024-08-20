using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// 
///</summary>
public class CameraDragManager : MonoBehaviour
{
    #region Variables
    // Variables.
    public bool canClick = true;
    #endregion

    #region Unity Methods

    void Start()
    {
    }

    void LateUpdate()
    {
        CinemachineCore.GetInputAxis = GetAxisCustom;
    }

    #endregion

    #region Private Methods
    // Private Methods.

    public float GetAxisCustom(string axisName)
    {
        if (axisName == "Mouse X")
        {
            if (Input.GetMouseButton(0))
            {
                return UnityEngine.Input.GetAxis("Mouse X");
            }
            else
            {
                return 0;
            }
        }
        else if (axisName == "Mouse Y")
        {
            if (Input.GetMouseButton(0))
            {
                return UnityEngine.Input.GetAxis("Mouse Y");
            }
            else
            {
                return 0;
            }
        }
        return UnityEngine.Input.GetAxis(axisName);
    }
    #endregion

    #region Public Methods
    // Public Methods.

    #endregion
}
