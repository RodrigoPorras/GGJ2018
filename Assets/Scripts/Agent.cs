using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {
	private int horario;
	private string hintHorario;
	private string nombre;
	private string hintNombre;
	private Voz voz;
	private string hintVoz;

	private string hintFace;
	private Face face;
	
	//Constructor
	public Agent (int _horario,string _hintHorario,string _nombre,string _hintNombre,Voz _voz,Face _face){
		horario = _horario;
		hintHorario = _hintHorario;
		nombre = _nombre;
		hintNombre = _hintNombre;
		voz = _voz;
		hintVoz = _voz.hint;
		hintFace = _face.predefineHint;
		face = _face;
		
	}
}
