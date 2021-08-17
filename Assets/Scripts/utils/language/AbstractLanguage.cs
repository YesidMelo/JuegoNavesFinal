public abstract class AbstractLanguage {

    public AbstractLanguage() {
        initMap();
    }

    protected abstract void initMap();

    public abstract string getNameTag(NameTagLanguage nameTag);
}