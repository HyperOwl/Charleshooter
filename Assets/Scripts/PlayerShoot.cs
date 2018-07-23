using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    [SerializeField]
    private GameObject barrel1;
    [SerializeField]
    private GameObject barrel2;
    [SerializeField]
    private GameObject laser;
	
	private void Update () {
		if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(laser, barrel1.transform.position, barrel1.transform.rotation, null);
            Instantiate(laser, barrel2.transform.position, barrel2.transform.rotation, null);
        }
	}
}
