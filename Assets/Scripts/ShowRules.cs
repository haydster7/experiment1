using UnityEngine;
using System.Collections;

public class ShowRules : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void main(bool show){
		GameObject.Find ("Main Menu/Background/MainMenu").SetActive(show);
		GameObject.Find ("Main Menu/Background/Rules").SetActive(!show);
	}
}
