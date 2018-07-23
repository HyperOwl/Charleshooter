using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField]
    private Vector2 panLimit;
    [SerializeField]
    private GameObject trackObject;
    private Vector2 pos;
    
	void Update () {
        if (!trackObject) return;
        pos.x = Mathf.Clamp(trackObject.transform.position.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(trackObject.transform.position.y, -panLimit.y, panLimit.y);
        transform.position = new Vector3(pos.x,pos.y,transform.position.z);
	}
}
