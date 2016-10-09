﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UserTable : MonoBehaviour {

	public GameObject avatar;
	public GameObject cardBack;

	/* Private variables */

	private const float CARD_SPACE = 28.0f;
	private const float CARD_Y = 21.0f;
	private float cardX = -146.0f;

	private string _userId;
	public string userId { get { return this._userId; } set { this._userId = value; } }


	private bool _isOccupied;
	public bool spaceOccupied { get { return this._isOccupied; } set {this._isOccupied = value; }}

	void Start () {
		_isOccupied = false;
	}

	void Update () {
	
	}

	public void addPhoto(int photoId){

		string imageName = null;

		if (photoId == 0) {
			
			imageName = "dino";

		} else if (photoId == 1) {

			imageName = "minion";

		} else if (photoId == 2) {

			imageName = "dory";

		} else if (photoId == 3) {

			imageName = "monster";

		} else if (photoId == 4) {

			imageName = "anger";

		} else if (photoId == 5) {

			imageName = "baymax";

		} else if (photoId == 6) {

			imageName = "dory";

		}
			
		Texture2D avaTex = Resources.Load ("images/avatar/"+imageName, typeof(Texture2D)) as Texture2D;

		avatar.GetComponent<Image> ().sprite = Sprite.Create (avaTex, new Rect (0, 0, avaTex.width, avaTex.height), new Vector2 (0.0f, 0.0f));


	}

	private void addCards(){
		
		GameObject card = Instantiate (cardBack,Vector3.zero, gameObject.transform.rotation) as GameObject;
		card.transform.SetParent (gameObject.transform, false);
		card.GetComponent<Animator> ().SetBool ("showCard", true);


		RectTransform m = card.GetComponent<RectTransform> ();
		m.anchoredPosition = new Vector2 (cardX, CARD_Y);

		cardX = cardX + CARD_SPACE;
	}

	void OnCollisionEnter2D(Collision2D c){
		Debug.Log ("collision");

		addCards ();

	}

}