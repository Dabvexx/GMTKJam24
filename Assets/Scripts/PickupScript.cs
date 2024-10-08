using UnityEngine;

///<summary>
///
///</summary>
public class PickupScript : MonoBehaviour
{
    #region Variables

    // Variables.
    [SerializeField] private CameraDragManager dm;

    [SerializeField] private string selectableTag = "Weight";

    private Transform _selection;

    #endregion Variables

    #region Unity Methods

    private void Start()
    {
        dm = FindObjectOfType<CameraDragManager>().GetComponent<CameraDragManager>();
    }

    private void Update()
    {
        // when we click on an object make it orient verticlly and lift it be x height above the ground, bring it closer when raycast down hits a sclae.
        // Locked objects, like the permenant objects.
        // also set dm canclick variable to false when holding click.
        // also display the weight of anything you pick up

        // Let go when let go of click
        if (_selection != null)
        {
            _selection.position = new Vector3(_selection.position.x + Input.GetAxis("Horizontal"), 0, _selection.position.z + Input.GetAxis("Vertical"));
            _selection.rotation = Quaternion.identity;
            _selection = null;
            dm.canClick = true;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log("We hit");
            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log("Mouse is down");
                var selection = hit.transform;
                if (selection.GetComponentInChildren<WeightScript>().CompareTag(selectableTag))
                {
                    //Debug.Log("Hit Weight");
                    if (!selection.GetComponentInChildren<WeightScript>().isLocked)
                    {
                        _selection = selection;
                        //Debug.Log("Ladies and gentlemen we got em");
                        _selection.parent = null;
                        dm.canClick = false;
                    }
                }
            }
        }
    }

    #endregion Unity Methods

    #region Private Methods

    // Private Methods.

    #endregion Private Methods

    #region Public Methods

    // Public Methods.

    #endregion Public Methods
}