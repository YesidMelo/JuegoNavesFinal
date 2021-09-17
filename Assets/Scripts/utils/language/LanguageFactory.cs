public class LanguageFactory{
    private AbstractLanguage abstractLanguage;

    public LanguageFactory() {
        setLanguageByDefault();
    }

    public AbstractLanguage getLanguageSelected() {
        if (abstractLanguage != null) {
            return abstractLanguage;
        }
        setLanguageByDefault();
        return abstractLanguage;
    }

    public void setLanguageByDefault(LaguageAvailable languaje= LaguageAvailable.SPAIN) {
        switch (languaje)
        {
            case LaguageAvailable.SPAIN:
            default:
                abstractLanguage = new SpainLanguage();
                break;
        }
    }
}

