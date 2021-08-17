using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Move { 
    UP,
    LEFT,
    RIGT,
    STOP
}

public enum Action { 
    ATTACK,
    DEFENSE
}

public enum CanvasAvailable
{
    ABOUT,
    CONFIGURATION_GAME,
    CONFIGURATION_SPACECRAFT,
    INTERACTION_GAME,
    LOAD_GAME,
    LOADING,
    MAIN_MENU,
    NEW_GAME,
    PAUSE,
    SPLASH
}

public enum StatusGame { 
    MAIN_MENU,
    IN_GAME,
    PAUSE,
}