﻿using UnityEngine;
using System;

[CreateAssetMenu(fileName = "BuildingDataInfo", 
                 menuName = "Building/BuildingData", order = 1)]

public class BuildingData : ScriptableObject {
    /// <summary>
    /// Variabile che indica quanta Popolazione massima posso possedere
    /// </summary>
    public int MyPeopleLimit;
    /// <summary>
    /// Da ridefinire.
    /// </summary>
    public float dimension = 0;
    /// <summary>
    /// Timer che gestisce l'evoluzione della costruzione
    /// </summary>
    public float timeMultiplier = 0.01f;
    /// <summary>
    /// La risorsa che l'edificio produce
    /// </summary>
    public int MyResources;

    /// <summary>
    /// Definisce la tipologia di Building
    /// </summary>
    public BuildingType TypeOfBuilding;
}

/// <summary>
/// Enumeratore che differenzia la tipologia di Edificio edificabile per i Players.
/// </summary>
public enum BuildingType
{
    Player1,
    Player2,
    Player3,
    Player4

}