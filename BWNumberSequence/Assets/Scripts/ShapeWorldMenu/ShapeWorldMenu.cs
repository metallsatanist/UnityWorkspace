using UnityEngine;
using System.Collections;

public class ShapeWorldMenu : MonoBehaviour {

	// Use this for initialization
	
	void OnDisable () {
		FingerGestures.OnFingerTap -= FingerGestures_OnFingerTap;
	}
	
	void Start () {
		FingerGestures.OnFingerTap += FingerGestures_OnFingerTap;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void FingerGestures_OnFingerTap( int fingerIndex, Vector2 fingerPos, int tapCount )
    {
		GameObject selection = PickObject(fingerPos);
		//Debug.Log(selection.name);
		if(selection == null) return;
		
		if(selection.name.StartsWith("Icon1")) {
			showAlertWithImage("unlockpopup_shapebuilding");
		}
		
		if(selection.name.StartsWith("Icon2")) {
			showAlertWithImage("unlockpopup_coloring");
		}
		
		if(selection.name.StartsWith("Icon3")) {
			showAlertWithImage("unlockpopup_senseofspace");
		}
		
		if(selection.name.StartsWith("Icon4")) {
			showAlertWithImage("unlockpopup_stickergame");
		}
    }
	
	private GameObject PickObject( Vector2 screenPos )
    {
        Ray ray = Camera.main.ScreenPointToRay( screenPos );
        RaycastHit hit;

        if( Physics.Raycast( ray, out hit ) )
            return hit.collider.gameObject;

        return null;
    }
	
	// Convert from screen-space coordinates to world-space coordinates on the Z = 0 plane
    private Vector3 GetWorldPos( Vector2 screenPos )
    {
        Ray ray = Camera.main.ScreenPointToRay( screenPos );

        // we solve for intersection with z = 0 plane
        float t = -ray.origin.z / ray.direction.z;

        return ray.GetPoint( t );
    }
	
	public static void showAlertWithImage (string imageName) {
		
		GameObject alert = Instantiate(Resources.Load("ComingSoonImages/Prefabs/ComingSoon")) as GameObject;
		CSAlertBox alertScript = alert.GetComponent<CSAlertBox>();
		alertScript.setAlertWithImage(imageName);
	}
}
