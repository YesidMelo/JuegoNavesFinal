using System.Collections.Generic;

public class SpainLanguage : AbstractLanguage
{
    private Dictionary<NameTagLanguage, string> values = new Dictionary<NameTagLanguage, string>();

    public override string getNameTag(NameTagLanguage nameTag)
    {
        return values[nameTag];
    }

    protected override void initMap()
    {
        //Generic
        values[NameTagLanguage.ABOUT] = "Acerca de";
        values[NameTagLanguage.ATTACK] = "Atacar";
        values[NameTagLanguage.CONFIGURATION] = "Configuracion";
        values[NameTagLanguage.CONTINUE] = "Continuar";
        values[NameTagLanguage.CREATE_GAME] = "Crear juego";
        values[NameTagLanguage.DEFENSE] = "Defender";
        values[NameTagLanguage.GO_BACK] = "Volver";
        values[NameTagLanguage.GAME_CREATED] = "Nombre Jugador: {0}, Fecha: {1}";
        values[NameTagLanguage.LIFE_PLAYER] = "Vida: {0}";
        values[NameTagLanguage.LOAD_GAME] = "Cargar juego";
        values[NameTagLanguage.NAME_GAME] = "Juego Galactico";
        values[NameTagLanguage.NEW_GAME] = "Nuevo juego";
        values[NameTagLanguage.PAUSE] = "Pausa";
        values[NameTagLanguage.PLACEHOLDER_NEW_GAME_PLAYER] = "Nombre jugador";
        values[NameTagLanguage.SAVE_AND_EXIT] = "Guardar y salir";

    }
}
