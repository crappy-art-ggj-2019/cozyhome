﻿using Assets.Scripts.DI_Framework;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using static GameManagerScript;

public class GameStartMechanicsScript : MonoBehaviour
{
    [Inject]
    public InjectorHelper injectorHelper;

    public Sprite barricade;
    public Sprite trap;
    public Sprite stone;
    public Sprite lightning;
    public Sprite meteor;
    public Sprite defensive;
    public Sprite offensive;

    List<GameObject> actions = new List<GameObject>();
    private Color defensiveC = new Color(61, 136, 207);
    private Color offensiveC = new Color(192, 44, 10);


    public void OnGameStartSignal(LevelStartSignal signal)
    {

        if (signal.currentObjective == objective.TakeHome)
            signal.currentObjective = objective.DefendHome;
        else
            signal.currentObjective = objective.TakeHome;

        var startPostionAttacker = GameObject.Find("/StartingPositionAttacker").transform;
        var startPostionDefender = GameObject.Find("/StartingPositionDefender").transform;
        var human = GameObject.Find("/human");
        var cowman = GameObject.Find("/monster");
        var cam = GameObject.Find("/CM vcam1").GetComponent<CinemachineVirtualCamera>();

        for (int a = 1; a <= 3; a++)
            actions.Add(GameObject.Find("HUDCanvas/Action" + a));

        // Set the different views and objectives
        if (signal.currentPlayerMode == playerEntity.Human)
        {
            cam.Follow = human.transform;

            injectorHelper.AddComponentToGameObject<CowmanAIScript>(cowman);
            injectorHelper.AddComponentToGameObject<PlayerBehaviour>(human);
        }
        else
        {
            cam.Follow = cowman.transform;
            injectorHelper.AddComponentToGameObject<HumanAIScript>(human);
            injectorHelper.AddComponentToGameObject<PlayerBehaviour>(cowman);
        }

        if ((signal.currentPlayerMode == playerEntity.Human && signal.currentObjective == objective.TakeHome)
            || (signal.currentPlayerMode == playerEntity.Cowman && signal.currentObjective == objective.DefendHome))
        {
            human.transform.position = startPostionAttacker.position;
            cowman.transform.position = startPostionDefender.position;
            human.tag = "Attacker";
            cowman.tag = "Defender";
        }
        else
        {
            human.transform.position = startPostionDefender.position;
            cowman.transform.position = startPostionAttacker.position;
            human.tag = "Defender";
            cowman.tag = "Attacker";
        }

        SetActions(signal);
    }


    private void SetActions(LevelStartSignal signal)
    {
        if (signal.currentPlayerMode == playerEntity.Human)
        {
            actions[0].GetComponent<Image>().color = defensiveC;
            foreach (Transform child in actions[0].transform)
            {
                if (child.name == "ItemIcon")
                    child.GetComponent<Image>().sprite = barricade;
                if (child.name == "TypeIcon")
                    child.GetComponent<Image>().sprite = defensive;
            }

            actions[1].GetComponent<Image>().color = offensiveC;
            foreach (Transform child in actions[1].transform)
            {
                if (child.name == "ItemIcon")
                    child.GetComponent<Image>().sprite = trap;
                if (child.name == "TypeIcon")
                    child.GetComponent<Image>().sprite = defensive;
            }

            actions[2].GetComponent<Image>().color = offensiveC;
            foreach (Transform child in actions[2].transform)
            {
                if (child.name == "ItemIcon")
                    child.GetComponent<Image>().sprite = stone;
                if (child.name == "TypeIcon")
                    child.GetComponent<Image>().sprite = offensive;
            }
        }
        else   // playing monster
        {
            actions[0].GetComponent<Image>().color = defensiveC;
            foreach (Transform child in actions[0].transform)
            {
                if (child.name == "ItemIcon")
                    child.GetComponent<Image>().sprite = barricade;
                if (child.name == "TypeIcon")
                    child.GetComponent<Image>().sprite = defensive;
            }

            actions[1].GetComponent<Image>().color = offensiveC;
            foreach (Transform child in actions[1].transform)
            {
                if (child.name == "ItemIcon")
                    child.GetComponent<Image>().sprite = lightning;
                if (child.name == "TypeIcon")
                    child.GetComponent<Image>().sprite = offensive;
            }

            actions[2].GetComponent<Image>().color = offensiveC;
            foreach (Transform child in actions[2].transform)
            {
                if (child.name == "ItemIcon")
                    child.GetComponent<Image>().sprite = meteor;
                if (child.name == "TypeIcon")
                    child.GetComponent<Image>().sprite = offensive;
            }
        }
    }
}
