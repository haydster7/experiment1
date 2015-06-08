using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	private GameObject[] objects;
	public bool allFound = false;

	// Use this for initialization
	void Start () {
		objects = GameObject.FindGameObjectsWithTag ("Note");
	}
	
	// Update is called once per frame
	void Update () {
		checkNotes();
		if (allFound) {
			Application.LoadLevel (0);
		}
	}

	void checkNotes(){
		if (!allFound) {
			allFound = true;
			for (int i = 0; (i < objects.Length) && (allFound); i++) {
				allFound = objects [i].GetComponent<Proximity> ().isfound;
			}
		}
	}
}
