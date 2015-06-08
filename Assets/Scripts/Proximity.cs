using UnityEngine;
using System.Collections;

public class Proximity : MonoBehaviour {

	public bool isfound = false;
	private bool playerWithin = false;

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player" && !isfound) {
			playerWithin = true;
			GameObject.Find ("Canvas").GetComponent<Canvas> ().enabled = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			playerWithin = false;
			GameObject.Find ("Canvas").GetComponent<Canvas> ().enabled = false;
		}

	}

	// Update is called once per frame
	void Update () {
		if(playerWithin){
			if(Input.GetKeyDown("e")){
				isfound = true;
				GameObject.Find ("Canvas").GetComponent<Canvas> ().enabled = false;
			}
		}
		this.transform.Find ("pPlane1").GetComponent<Renderer> ().enabled = !isfound;
	}


}
