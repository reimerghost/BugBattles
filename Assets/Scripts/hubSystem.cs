using UnityEngine;
using System.Collections;

public class hubSystem : MonoBehaviour {
    
    private string testingText;
    private int destroyed;
    private bugData bicho;
    void OnGUI()
    {
        GUI.Label(escalarGUI.ResizeGUI(new Rect(5, 0, 200, 30)), "HP: "+bicho.getVidaActual()+"/"+bicho.getVidaTotal());
        GUI.Label(escalarGUI.ResizeGUI(new Rect(5, 30, 200, 30)), "ATQ: "+bicho.getAtqTotal()+
		          " | DEF: "+bicho.getDefTotal()
		          +" | VEL: "+bicho.getVelTotal());
        GUI.Label(escalarGUI.ResizeGUI(new Rect(5, 60, 200, 30)), "NIVEL: "+bicho.nivel+"| EXP: "+bicho.getCadenaEXP());
        GUI.Label(escalarGUI.ResizeGUI(new Rect(5, 90, 400, 30)), "DEMO - WORK IN PROGRESS");
        GUI.Label(escalarGUI.ResizeGUI(new Rect(5, 120, 200, 30)), testingText);
    }
	// Use this for initialization
	void Start () {
        //pared_hor_1.transform.position = new Vector2(escalarGUI.getPosX(pared_hor_1), escalarGUI.getPosY());
        bicho = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<bugData>();
        testingText = "Enemigos destruidos: 0";
	}

    void Update()
    {
        if (bicho.getVidaActual() <= 0)
        {
            Application.LoadLevel("menuInicio");
        }
    }

    public void actualizaEnemigos(float exp)
    {
        destroyed++;
        testingText = "Enemigos destruidos: "+destroyed;
        bicho.SubirExperiencia(exp);
    }
    
}
