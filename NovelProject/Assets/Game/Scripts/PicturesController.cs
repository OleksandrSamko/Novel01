using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PicturesController : MonoBehaviour {
	//show in inspector contain name and pic obj
	[SerializeField]
	public Picture[] pictures;

	private string lastPictureKey;
	private Image image;

	// Use this for initialization
	void Start () {
		image = GetComponent<Image>();
	}

	public void ShowPicture(string name){
		//nothing to search
		if(name.Length<1){
			DisablePicture();
			return;
		}
		//find pic
		foreach(Picture pic in pictures){
			if(pic.key == name){
				image.sprite = pic.picture;
				return;
			}
		}
		//nothing
		Debug.Log("Picture not found");
		return;
	}

	public void DisablePicture(){
			image.sprite = null;
	}

}
