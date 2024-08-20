using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// 
///</summary>
public class TitleScreenManager : MonoBehaviour
{
    #region Variables
    // Variables.
    [SerializeField] private CameraDragManager dragManager;
    private Vector3 movePoint;
    #endregion

    #region Unity Methods

    void Start()
    {
        movePoint = transform.position;
        CinemachineCore.GetInputAxis = GetAxisCustom;
    }



    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragManager.enabled = true;
            movePoint += Vector3.up * 40;
        }

        transform.position = Vector3.MoveTowards(transform.position, movePoint, 5 * Time.deltaTime);
        
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
