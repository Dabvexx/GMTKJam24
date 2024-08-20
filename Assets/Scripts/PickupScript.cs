using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// 
///</summary>
public class PickupScript : MonoBehaviour
{
    #region Variables
    // Variables.
    [SerializeField] private CameraDragManager dm;
    #endregion

    #region Unity Methods

    void Start()
    {
    }

    void Update()
    {
        // when we click on an object make it orient verticlly and lift it be x height above the ground, bring it closer when raycast down hits a sclae.
        // Locked objects, like the permenant objects.
        // also set dm canclick variable to false when holding click.
        // also display the weight of anything you pick up
    }

    #endregion

    #region Private Methods
    // Private Methods.
    
    #endregion

    #region Public Methods
    // Public Methods.
    
    #endregion
}
