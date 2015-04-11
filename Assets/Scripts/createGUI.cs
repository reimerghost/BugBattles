using UnityEngine;
using System.Collections;

public class createGUI : MonoBehaviour {

    public string[] titulo;
    public string[] Escena;
    public float alto = 0, ancho = 0;

	// Use this for initialization

    void OnGUI()
    {
        if (alto == -1)
        {
            alto = Screen.height / 2;
        }

        if (ancho == -1)
        {
            ancho = Screen.width / 2;
        }

    //------------------------
        for (int i = 0; i < titulo.Length;i++ )
        {
            if (GUI.Button(escalarGUI.ResizeGUI(new Rect(alto, ancho+i * 90, 250, 40)), titulo[i]))
            {
                if ("Salir".Equals(Escena[i]))
                {
                    Application.Quit();
                    Debug.Log("OUT");
                }else{
                    Application.LoadLevel(Escena[i].ToString());
                }
                
            }
        }
    }

	void Start () {
        

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
