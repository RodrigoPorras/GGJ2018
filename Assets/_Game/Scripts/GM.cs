using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {
	public static GM instance;
	public GameObject material;

	void Awake () {
		if(instance == null){
			instance = this;
		}else{
			Destroy(this);
		}

	}
		
		

	// Update is called once per frame
	void Update () {
		
	}

	public List<Agent> CreateAgents(){
		//cargo las listas con los valores de los array para poder ir eliminando los hint elegidos
		HintContainer.instance.LoadListsForGenerateAgentsAgain();

		List<Agent> listAllAgents = new List<Agent>();

		foreach (var face in HintContainer.instance.faces){
			int ran = 0;
			Voz agentVoz;
			string nombre;
			string hintNombre;
			int horario;
			string hintHorario;

			if(face.sexo == 'F'){
				//set voz  para mujer
				ran = Random.Range(0,HintContainer.instance.listVocesMujeres.Count);
				agentVoz = HintContainer.instance.listVocesMujeres[ran];
				HintContainer.instance.listVocesMujeres.RemoveAt(ran);

				//set nombre para mujer
				ran = Random.Range(0,HintContainer.instance.listNombresMujeres.Count);
				nombre = HintContainer.instance.listNombresMujeres[ran].nombre;
				hintNombre = HintContainer.instance.listNombresMujeres[ran].hint;
				HintContainer.instance.listNombresMujeres.RemoveAt(ran);
			}else{
				//set voz para hombre 
				ran = Random.Range(0,HintContainer.instance.listVocesHombres.Count);
				agentVoz = HintContainer.instance.listVocesHombres[ran];
				HintContainer.instance.listVocesHombres.RemoveAt(ran);

				//set nombre para hombre y hintnombre
				ran = Random.Range(0,HintContainer.instance.listNombresHombres.Count);
				nombre = HintContainer.instance.listNombresHombres[ran].nombre;
				hintNombre = HintContainer.instance.listNombresHombres[ran].hint;
				HintContainer.instance.listNombresHombres.RemoveAt(ran);
			}

			//set para el horario y el hint horario
			ran = Random.Range(0,HintContainer.instance.listHorarios.Count);
			horario = HintContainer.instance.listHorarios[ran].horario;
			hintHorario = HintContainer.instance.listHorarios[ran].hintHorario;
			HintContainer.instance.listHorarios.RemoveAt(ran);

			//creando el agente
			Agent agente = new Agent(horario,hintHorario,nombre,hintNombre,agentVoz,face);
			listAllAgents.Add(agente);
		}

		return listAllAgents;
	}
}
