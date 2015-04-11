using UnityEngine;
using System.Collections;

public class equipoData : MonoBehaviour {
    //FUNDAMENTALES
    public string Nombre;
    public float vida, damage;
    public int nivel;
    public float exp;
    public int tipo;

    //Plus FUNDAMENTALES
    public float vidaPlus, plusRegen, plusExp;
    //Plus BASES
    public float atqPlus, defPlus, velPlus, giroPlus;
    //
    public int lvlReq;
    public float costoReparo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}

	//Plus FUNDAMENTALES
	public float getVidaPlus()
	{
		return vidaPlus;
	}
	public float getplusRegen()
	{
		return plusRegen;
	}
	public float getplusExp()
	{
		return plusExp;
	}
	//---------------
	//Plus BASES
	public float getAtqPlus()
	{
		return atqPlus;
	}
	public float getDefPlus()
	{
		return defPlus;
	}
	public float getVelPlus()
	{
		return velPlus;
	}
	public float getGiroPlus()
	{
		return giroPlus;
	}

    public float getVidaActual(){
        return (vida-damage);
    }
}
