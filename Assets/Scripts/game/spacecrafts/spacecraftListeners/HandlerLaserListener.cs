public class HandlerLaserListener : HandlerLaserDelegate
{
    private AbstractSpacecraft spacecraft;

    public HandlerLaserListener(
        AbstractSpacecraft spacecraft
    ) {
        this.spacecraft = spacecraft;
    }      
}
