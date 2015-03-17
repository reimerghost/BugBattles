using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TouchInput : MonoBehaviour {

    Image image;
	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();	
	}

    public void Red()
    {
        image.color = Color.red;
    }

    public void Blue()
    {
        image.color = Color.blue;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
