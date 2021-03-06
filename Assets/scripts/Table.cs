﻿using UnityEngine;
using System.Collections;

public class Table : MonoBehaviour {


	private const string tablePlayerTag = "tablePlayer";
	public GameObject overlay;
	public GameObject userActions;
	public GameObject cards;

	public GameObject f;

	// Use this for initialization
	void Start () {
	



	}

	public void distribute(){
		f.GetComponent<Animator> ().SetBool ("distribute", true);
	}

	public void showCardUser(){


		// hide all user action buttons
		int childCount = userActions.transform.childCount;

		 for (int m = 0; m < childCount; m++) {
			GameObject child = userActions.transform.GetChild (m).gameObject;
			child.GetComponent<Animator> ().SetBool ("showCard", true);
		}


		Invoke ("show", 1.3f);


	}

	private void show(){

		overlay.SetActive (true);
		overlay.GetComponent<OverlayScript> ().toggleCards ();
	}



		
	/*
	 * 
	 * Get the first vacant seat on the table
	 * 
	 */ 

	public void addUser(){

		int childCount = gameObject.transform.childCount;
		GameObject emptySpace = null;
		UserTable t = null;

		for(;childCount > 0;childCount--){

			GameObject childObject = gameObject.transform.GetChild (childCount).gameObject;

			if (childObject.tag == tablePlayerTag) {
				
				t = childObject.GetComponent<UserTable> ();

				if (!t.getIsOccupied ()) { 
					emptySpace = childObject;
					break;
				}

			}
		}

		t.addPhoto (0);



		
	}

	// Update is called once per frame
	void Update () {
	
	}
}
