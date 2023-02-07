using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngineInternal;

public static partial class Functions
{
    #region GameObject name
    public const string NAME_OBJCANVAS = "ObjectCanvas";
    public const string NAME_BOARD = "Board";
    public const string NAME_TARGET = "Target";
    public const string NAME_ANTCAVE = "AntCave";
    public const string NAME_CAKE = "Cake";

    public const string NAME_UIMANAGER = "UIManager";
    public const string NAME_UICANVAS = "UICanvas";
    public const string NAME_UI_DESC = "Description";

    public const string NAME_ANT_HP = "CurrentHP";
    public const string NAME_ANT_CAKE = "Cake";

    public const string NAME_CANNONTOOLTIP = "CannonCreateTooltip";
    #endregion

    #region Prefab name
    public const string NAME_ANT_PREFAB = "Ant";
    public const string NAME_CANNON_PREFAB = "Cannon";
    #endregion

    #region Resource files location
    public const string FILELOC_RESOURCES_PREFAB = "Prefabs/";
    #endregion

    #region Prefabs
    public static readonly GameObject PREFAB_ANT = Resources.Load($"{Functions.FILELOC_RESOURCES_PREFAB}{Functions.NAME_ANT_PREFAB}") as GameObject;
    public static readonly GameObject PREFAB_CANNON = Resources.Load($"{Functions.FILELOC_RESOURCES_PREFAB}{Functions.NAME_CANNON_PREFAB}") as GameObject;
    #endregion
}