using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public Transform player;	// A variable that stores a reference to our Player
	public Vector3 offset;		// A variable that allows us to offset the position (x, y, z)
	// Start is called before the first frame update 
    void Start ()
    {
        offset = transform.position - player.position;
    }
    
	// Update is called once per frame
	void Update () 
    {
        Vector3 targetPos = player.position + offset;
        targetPos.x = 0;
		transform.position = targetPos;
	}
}
