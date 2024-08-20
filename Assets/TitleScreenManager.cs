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
    }



    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragManager.enabled = true;
            movePoint += Vector3.up * 4;
        }

        Vector3.MoveTowards(transform.position, movePoint, Time.deltaTime * 5);
        
    }

    #endregion

    #region Private Methods
    // Private Methods.
    
    #endregion

    #region Public Methods
    // Public Methods.
    
    #endregion
}
