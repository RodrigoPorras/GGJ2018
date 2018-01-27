using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
	public int[] horario;
	public string hintHorario;
	public string nombre;
	public string hintNombre;
	public Voz voz;
	public string hintVoz;

	public string hintFace;
	public Face face;
	
	//Constructor
	public Agent (int[] _horario,string _hintHorario,string _nombre,string _hintNombre,Voz _voz,Face _face)
    {
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
