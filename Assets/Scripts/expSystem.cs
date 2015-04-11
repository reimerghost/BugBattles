using UnityEngine;
using System.Collections;
//YA NO SE USA
public class expSystem : MonoBehaviour {

	float actualExp,expToLevelUp, actualLvl=1;
	void OnGUI()
	{
		GUI.Label (new Rect(0,0, 200, 50), "Nivel: "+actualLvl);
		GUI.Label (new Rect(0,15, 200, 50), "Experiencia: "+actualExp+"/"+expToLevelUp);
	}

	// Use this for initialization
	void Start () {
		expToLevelUp = 100;
	}
	
	// Update is called once per frame
	void Update () {
		if(actualExp >= expToLevelUp){
			actualLvl +=1;

			expToLevelUp +=(4 * (actualLvl*actualLvl*actualLvl)) / 5;
		}
	}

	public void SubirExperiencia(float exp){
		actualExp += exp;
	}
}
