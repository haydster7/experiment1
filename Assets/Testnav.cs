using UnityEngine;
using System.Collections;

public class Testnav : MonoBehaviour {
	public GameObject target;
	// Use this for initialization
	void Start () {
		GetComponent<NavMeshAgent>().destination = target.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
