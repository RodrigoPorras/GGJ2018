using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selection : MonoBehaviour
{
    public Agent agent;
    Image image;
    Text nameText;
    public int index;
    public Light[] lights;

    private void Awake()
    {
        image = GetComponent<Image>();
        nameText = transform.GetChild(1).GetComponent<Text>();
    }

    public void Interact()
    {
        if (Plug.Instance.isSelected)
        {
            Plug.Instance.Connect();
            AudioSystem.Instance.PlaySound("plugin");
            bool correct = GM.instance.RevealAgent(index);
            StartCoroutine(ConnectionFeedback(correct));
        }
    }

    public void UpdateSlot()
    {
        image.sprite = agent.face.faceSprite;
        nameText.text = agent.nombre;
    }

    /// <summary>
    ///  Activates the corresponding light of the slot
    ///  0 for correct/wrong light
    ///  1 for Online light
    /// </summary>
    /// <param name="lightNum">
    /// 0 for correct/wrong light
    ///  1 for Online light</param>
    /// <param name="col">Color to be shown</param>
    void TurnOnLight(int lightNum, Color col)
    {
        lights[lightNum].enabled = true;
        lights[lightNum].color = col;
    }

    void TurnOffLight(int lightNum)
    {
        lights[lightNum].enabled = false;
    }

    private void Update()
    {
        bool agentActive = false;
        for (int i = 0; i < agent.horario.Length; i++)
        {
            if (GM.instance.ActualMin == agent.horario[i])
            {
                agentActive = true;
            }
        }
        if (agentActive)
            TurnOnLight(1, Color.yellow);
        else
            TurnOffLight(1);
    }

    WaitForSeconds lightWait = new WaitForSeconds(1f);
    WaitForSeconds unplugWait = new WaitForSeconds(0.35f);
    IEnumerator ConnectionFeedback(bool correct)
    {
        if (correct)
        {
            TurnOnLight(0, Color.green);
            AudioSystem.Instance.PlaySound("Correct");
        }
        else
        {
            TurnOnLight(0, Color.red);
            AudioSystem.Instance.PlaySound("Incorrect");
        }
        yield return lightWait;
        TurnOffLight(0);
        AudioSystem.Instance.PlaySound("Unplug");
        yield return unplugWait;
        Plug.Instance.Reset();
    }

    public void CheckVoice()
    {
        AudioSystem.Instance.PlayMusic(agent.voz.voz);
    }

}
