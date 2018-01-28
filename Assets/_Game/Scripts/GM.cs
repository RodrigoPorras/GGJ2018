using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    // Public properties
	public static GM instance;
    public Selection[] selections;
	public TextMesh clock,timer;
    int actualMin;
    public int ActualMin
    {
        get { return actualMin; }
    }
    // Private properties
	float currentTime = 0;
	int timeLeft = 300; //segundos totales, en este caso 5 minutos son 300 segundos
	int timeBefore = 0;
    int score = 0;

	Agent correctAgent;
	int correctAgentIndex;

	void Awake ()
    {
		if(instance == null){
			instance = this;
		}else{
			Destroy(this);
		}
	}

    private void Start()
    {
        Setup();
		currentTime = ((System.DateTime.Now.Hour%12) * 60) + (System.DateTime.Now.Minute);
    }

    // Update is called once per frame
    void Setup ()
    {
        List<Agent> agents = CreateAgents();
		correctAgentIndex = Random.Range(0, agents.Count); // TODO Cambiar a selection.lenght caundo hayan mas de 9 agentes
		correctAgent = agents[correctAgentIndex];

        for (int i = 0; i < selections.Length; i++)
        {
            if (agents.Count> i)
            {
                selections[i].agent = agents[i];
                selections[i].UpdateSlot();
            }
        }

		//poner la primera pista


	}

	
	// Update is called once per frame
	
	void Update ()
    {
		currentTime += Time.deltaTime;
		int minuto = (int) currentTime % 60;//residuo que indica la cantidad en segundos
		int hora = (int) (currentTime / 60);//division que representa la cantidad en minutos
		clock.text = hora.ToString("00")+":"+minuto.ToString("00");
        actualMin = minuto;

		//Timer
		if (timeLeft > 0) {//solo empieza a decrementar si tengo que decrementar
			if (timeBefore !=  (int )Time.time) {//si mi tiempo anterior es diferente a mi tiempo actual en int
				timeBefore = (int) Time.time;
				timeLeft --;//decremento un segundo
				int segundosT = (int) timeLeft % 60;//residuo que indica la cantidad en segundos
				int minutosT = (int) (timeLeft / 60);//division que representa la cantidad en minutos
				timer.text = minutosT.ToString("00")+":"+segundosT.ToString("00");
			}
		}	
	}



	public List<Agent> CreateAgents()
    {
		//cargo las listas con los valores de los array para poder ir eliminando los hint elegidos
		HintContainer.instance.LoadListsForGenerateAgentsAgain();

		List<Agent> listAllAgents = new List<Agent>();

		foreach (var face in HintContainer.instance.faces){
			int ran = 0;
			Voz agentVoz;
			string nombre;
			string hintNombre;
			int[] horario;
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

        for (int i = 0; i < listAllAgents.Count; i++)
        {
            Agent temp = listAllAgents[i];
            int x = Random.Range(0, listAllAgents.Count);
            listAllAgents[i] = listAllAgents[x];
            listAllAgents[x] = temp;
        }

		return listAllAgents;
	}

    public bool RevealAgent(int index)
    {
        if (correctAgentIndex == index)
        {
            timeLeft += 15;
            score++;
            StartCoroutine(SetNextRound());
            return true;
        }
        timeLeft -= 20;
        return false;
    }

    WaitForSeconds waitForNextRound = new WaitForSeconds(1);
    IEnumerator SetNextRound()
    {
        yield return waitForNextRound;
        Setup();
    }
}
