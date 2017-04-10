﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BuildingView : MonoBehaviour
{
    public TextMesh TextActualStatus;

    public BuildingData Data;

    Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
        TextActualStatus.text = "In Costruzione ";
        //Debug.Log("Actual Life " + this.Data.BuildingLife);
        //TextActualPeople.text = "People: " + player.Population;  
    }
    public void Init(BuildingData _buildingData)
    {
        //CheckRenderer(GetComponent<Renderer>());
        Data = _buildingData;
        TimeEventManager.OnEvent += OnUnitEvent;
        UpdateGraphic();
    }
 

    void OnUnitEvent(TimedEventData _eventData)
    {
        #region Event
        if (_eventData.ID == "Costruzione" && Data.IsEnded == false)
        {
            Data.BuildingTime--;
            if (Data.BuildingTime == 0)
            {
                rend.enabled = true;
                TextActualStatus.text = "";
                Data.IsEnded = true;
            }     
        }
        if (Data.IsEnded == true)
        {
            foreach (TimedEventData ev in Data.TimedEvents)
            {
                switch (ev.ID)
                {
                    case "FineMese":
                        Debug.Log("Mese");
                        break;
                    case "FoodProduction":
                        GameManager.I.buildingManager.IncreaseResources(this);
                        break;
                    case "WoodProduction":
                        GameManager.I.buildingManager.IncreaseResources(this);
                        break;
                    case "StoneProduction":
                        GameManager.I.buildingManager.IncreaseResources(this);
                        break;
                    case "FaithProduction":
                        GameManager.I.buildingManager.IncreaseResources(this);
                        break;
                    case "SpiritProduction":
                        GameManager.I.buildingManager.IncreaseResources(this);
                        break;
                    case "FineAnno":
                        break;
                    case "Degrado":
                        GameManager.I.buildingManager.RemoveLife(this);
                        if (Data.BuildingLife < 1)
                            destroyMe();
                        break;
                    default:
                        break;
                }

            }
        } 
                 Debug.LogFormat("Edificio {0} ha ricevuto l'evento {1}", Data.ID, _eventData.ID);
        #endregion
    }


    public void UpdateGraphic()
    {
        TextActualStatus.text = "ahahah";
    }

    //public void OnTimedEventDataChanged(TimedEventData _timedEventData) {

    //    if (_timedEventData.IsEnded == true)
    //    {
    //        Data.isBuilt = true;
    //        CheckRenderer(GetComponent<Renderer>());
    //    }
    //}

    /// <summary>
    /// API che distrugge il building.
    /// </summary>
    public void destroyMe()
    {
        GameManager.I.gridController.Cells[(int)Data.GetGridPosition().x, (int)Data.GetGridPosition().y].SetStatus(CellDoomstock.CellStatus.Empty);
        //toglie tutti i popolani dall'edificio e le rimette in POZZA
        Data.RemoveAllPopulationFromBuilding();
        TimeEventManager.OnEvent -= OnUnitEvent;
        transform.DOPunchScale(Vector3.one, 0.5f).OnComplete(() =>
        {
         if (OnDestroy != null)
            OnDestroy(this);
            Destroy(gameObject);

        });
        
    }


    private void OnDisable()
    {
        TimeEventManager.OnEvent -= OnUnitEvent;

    }

    #region Events
    public delegate void BuildingEvent(BuildingView _buildingView);
    public static BuildingEvent OnDestroy;
    
    #endregion
}
