using UnityEngine;
using System.Collections;
using System.Collections.Generic;


// This is actually OUTSIDE of the Utils Class
public enum BoundsTest
{
    center, // Is the center of the GameObject on screen?
    onScreen, // Are the bounds entirely on screen?
    offScreen // Are the bounds entirely off screen?
}

public class Utils : MonoBehaviour
{
    //============================= Bounds Functions =============================\\

    // Make a static read-only public property camBounds
    static public Bounds camBounds
    { // 1
        get
        {
            // if _camBounds hasn't been set yet
            if (_camBounds.size == Vector3.zero)
            {
                // SetCameraBounds using the default Camera
                SetCameraBounds();
            }
            return (_camBounds);
        }
    }
    // This is the private static field that camBounds uses
    static private Bounds _camBounds; // 2
                                      // This function is used by camBounds to set _camBounds and can also be
                                      // called directly.
    public static void SetCameraBounds(Camera cam = null)
    { // 3
      // If no Camera was passed in, use the main Camera
        if (cam == null) cam = Camera.main;
        // This makes a couple of important assumptions about the camera!:
        // 1. The camera is Orthographic
        // 2. The camera is at a rotation of R:[0,0,0]
        // Make Vector3s at the topLeft and bottomRight of the Screen coords
        Vector3 topLeft = new Vector3(0, 0, 0);
        Vector3 bottomRight = new Vector3(Screen.width, Screen.height, 0);
        // Convert these to world coordinates
        Vector3 boundTLN = cam.ScreenToWorldPoint(topLeft);
        Vector3 boundBRF = cam.ScreenToWorldPoint(bottomRight);
        // Adjust their zs to be at the near and far Camera clipping planes
        boundTLN.z += cam.nearClipPlane;

        boundBRF.z += cam.farClipPlane;
        // Find the center of the Bounds
        Vector3 center = (boundTLN + boundBRF) / 2f;
        _camBounds = new Bounds(center, Vector3.zero);
        // Expand _camBounds to encapsulate the extents.
        _camBounds.Encapsulate(boundTLN);
        _camBounds.Encapsulate(boundBRF);

    }

  

    // Checks to see whether Bounds lilB are within Bounds bigB
    public static Vector3 BoundsInBoundsCheck(Bounds bigB, Bounds lilB)
    {
        // The behavior of this function is different based on the BoundsTest
        // that has been selected.
        // Get the center of lilB
        Vector3 pos = lilB.center;
        // Initialize the offset at [0,0,0]
        Vector3 off = Vector3.zero;
     
        if (bigB.Contains(lilB.min) && bigB.Contains(lilB.max))
        {
            return (Vector3.zero);
        }
        if (lilB.max.x > bigB.max.x)
        {
            off.x = lilB.max.x - bigB.max.x;
        }
        else if (lilB.min.x < bigB.min.x)
        {
            off.x = lilB.min.x - bigB.min.x;
        }
        if (lilB.max.y > bigB.max.y)
        {
            off.y = lilB.max.y - bigB.max.y;
        }
        else if (lilB.min.y < bigB.min.y)
        {
            off.y = lilB.min.y - bigB.min.y;
        }
        if (lilB.max.z > bigB.max.z)
        {
            off.z = lilB.max.z - bigB.max.z;
        }
        else if (lilB.min.z < bigB.min.z)
        {
            off.z = lilB.min.z - bigB.min.z;
        }
        return (off);
                    
    }

    //============================ Transform Functions ===========================\\
    // This function will iteratively climb up the transform.parent tree
    // until it either finds a parent with a tag != "Untagged" or no parent
    public static GameObject FindTaggedParent(GameObject go)
    {
        // If this gameObject has a tag
        if (go.tag != "Untagged")
        {
            // then return this gameObject
            return (go);
        }
        // If there is no parent of this Transform
        if (go.transform.parent == null)
        {
            // We've reached the top of the hierarchy with no interesting tag
            // So return null
            return (null);
        }
        // Otherwise, recursively climb up the tree
        return (FindTaggedParent(go.transform.parent.gameObject));
    }
    // This version of the function handles things if a Transform is passed in
    public static GameObject FindTaggedParent(Transform t)
    {
        return (FindTaggedParent(t.gameObject));
    }


	//=========================== Materials Functions ============================\\
	// Returns a list of all Materials on this GameObject or its children
	static public Material[] GetAllMaterials( GameObject go ) {
		List<Material> mats = new List<Material>();
		Renderer renderer = go.GetComponent<Renderer>();
		if (renderer != null) {
			mats.Add(renderer.material);
		}
		foreach( Transform t in go.transform ) {
			mats.AddRange( GetAllMaterials( t.gameObject ) );
		}
		return( mats.ToArray() );
	}


}