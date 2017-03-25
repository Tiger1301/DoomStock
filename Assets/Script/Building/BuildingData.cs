﻿using UnityEngine;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BuildingDataInfo", 
                 menuName = "Building/BuildingData", order = 1)]

public class BuildingData : ScriptableObject, ISelectable {

    public string UniqueID { get; set; }

    /// <summary>
    /// identifica il tipo di edificio
    /// </summary>
    public String ID;
    /// <summary>
    /// la risorsa population che ha è assegnata al
    /// </summary>
    public int Population;
    /// <summary>
    /// Variabile che indica quanta Popolazione massima posso possedere
    /// </summary>
    public int PopulationLimit;
    /// <summary>
    /// Elenco di risorse necessarie per costruire l'edificio
    /// </summary>
    public int WoodToBuild,StoneToBuild;
    /// <summary>
    /// Dichiara se un Building ha termianto il suo tempo di costruzione
    /// </summary>
    public bool isBuilt;
    /// <summary>
    /// Oggetto prefab dell edificio
    /// </summary> 
    public BuildingView BuildPrefab;
    /// <summary>
    /// Variabile che indica la potenza di "fuoco" dell'edificio
    /// </summary>
    public int Attack;
    /// <summary>
    /// Variabile che indica ogni quanto l'deificio può attaccare
    /// </summary>
    public float FireRateo;
    /// <summary>
    /// Variabile che indica la resistenza al danno dei nemici
    /// </summary>
    public int DamageResistance;
    /// <summary>
    /// Variabile che indica il costo di Manuntenzione
    /// </summary>
    public int Maintenance;
    /// <summary>
    /// Aumenta il LimiteMassimo della Popolazione
    /// </summary>
    public int IncreaseMaxPopulation;
    /// <summary>
    /// Vita dell' edificio
    /// </summary>
    public int BuildingLife;
    /// <summary>
    /// Variabile utilizzata per il Degrado
    /// </summary>
    public int DecreaseBuildingLife;
    /// <summary>
    /// Lista degli eventi a cui questo edificio risponde.
    /// </summary>
    public List<TimedEventData> TimedEvents;
    /// <summary>
    /// Lista di Risorse che l'edifico puo creare.
    /// </summary>
    public List<BaseResourceData> BaseResources;

  

    public void Awake() {
        UniqueID = ID;
        
    }

    
}

