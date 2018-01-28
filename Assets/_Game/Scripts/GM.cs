using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    // Public properties
	public static GM instance;
    public Selection[] selections;
	public TextMesh clock,timer,lobbyClock;
    public GameObject[] hints;
    public Text[] hintsTexts;
    // Private properties
    float currentTime = 0;
	int timeLeft = 30; //segundos totales, en este caso 5 minutos son 300 segundos
	int timeBefore = 0;
    int score = 0;
    int actualMin;
    int correctAgentIndex;
    int actualHint;
    Agent correctAgent;
	

    // Properties
    public int ActualMin
    {
        get { return actualMin; }
    }

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
		correctAgentIndex = Random.Range(0, selections.Length); // TODO Cambiar a selection.lenght caundo hayan mas de 9 agentes
		correctAgent = agents[correctAgentIndex];

        for (int i = 0; i < selections.Length; i++)
        {
            if (agents.Count> i)
            {
                selections[i].agent = agents[i];
                selections[i].UpdateSlot();
            }
        }
        int[] hintOrder = new int[4] { 0, 1, 2, 3};

        for (int i = 0; i < hintOrder.Length; i++)
        {
            int temp = hintOrder[i];
            int x = Random.Range(0, hintOrder.Length);
            hintOrder[i] = hintOrder[x];
            hintOrder[x] = temp;
        }
        //poner la primera pista
        
        for (int i = 0; i < hints.Length; i++)
        {
            switch (hintOrder[i])
            {
                case 0:
                    hintsTexts[i].text = correctAgent.hintFace;
                    break;
                case 1:
                    hintsTexts[i].text = correctAgent.hintHorario;
                    break;
                case 2:
                    hintsTexts[i].text = correctAgent.hintNombre;
                    break;
                case 3:
                    hintsTexts[i].text = correctAgent.hintVoz;
                    break;
            }
        }
        actualHint = 1;
	}

	
	// Update is called once per frame
	
	void Update ()
    {
		currentTime += Time.deltaTime;
		int minuto = (int) currentTime % 60;//residuo que indica la cantidad en segundos
		int hora = (int) (currentTime / 60);//division que representa la cantidad en minutos
		clock.text = lobbyClock.text = hora.ToString("00")+":"+minuto.ToString("00");
        actualMin = minuto;

		//Timer
        int segundosT = 0;
        int minutosT = 0;
		if (timeLeft > 0) {//solo empieza a decrementar si tengo que decrementar
			if (timeBefore !=  (int )Time.time) {//si mi tiempo anterior es diferente a mi tiempo actual en int
				timeBefore = (int) Time.time;
				timeLeft --;//decremento un segundo
				segundosT = (int) timeLeft % 60;//residuo que indica la cantidad en segundos
				minutosT = (int) (timeLeft / 60);//division que representa la cantidad en minutos
				timer.text = minutosT.ToString("00")+":"+segundosT.ToString("00");

                //verificando el timer para saber si esta a punto de perder y cambiar la musica
                if(timeLeft < 15){
                    MusicManager.instance.SetCurrentContex(2);
                }else{
                    MusicManager.instance.SetCurrentContex(1);
                }
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
            ModifyTime( 15);
            score++;
            StartCoroutine(SetNextRound());
            return true;
        }
        ModifyTime(-20);
        return false;
    }

    void ModifyTime(int value)
    {
        timeLeft += value;
    }

    public void AskForHint()
    {
        if (actualHint < hints.Length && Plug.Instance.isSelected)
        {
            ModifyTime(-10);
            hints[actualHint].SetActive(true);
            actualHint++; 
        }
    }

    WaitForSeconds waitForNextRound = new WaitForSeconds(1);
    IEnumerator SetNextRound()
    {
        yield return waitForNextRound;
        Setup();
    }
}
