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
        values[NameTagLanguage.ATTACK] = "Atacar";
        values[NameTagLanguage.DEFENSE] = "Defender";
        values[NameTagLanguage.CONTINUE] = "Continuar";
        values[NameTagLanguage.NAME_GAME] = "Juego Galactico";

    }
}
