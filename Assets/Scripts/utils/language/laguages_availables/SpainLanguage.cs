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
        values[NameTagLanguage.NAME_GAME] = "Juego Galactico";
        values[NameTagLanguage.CONTINUE] = "Continuar";

    }
}
