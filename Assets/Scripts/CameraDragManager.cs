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
    [SerializeField] private GameObject scale;
    CinemachineVirtualCamera cam;
    #endregion

    #region Unity Methods

    void Start()
    {
    }

    private void OnEnable()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
        cam.Follow = scale.transform;
        cam.LookAt = scale.transform;
        cam.GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance = 15f;
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
