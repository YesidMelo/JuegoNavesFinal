public class LanguageFactory{
    private AbstractLanguage abstractLanguage;

    public LanguageFactory() {
        setLanguageByDefault();
    }

    AbstractLanguage getLanguageSelected() {
        if (abstractLanguage != null) {
            return abstractLanguage;
        }
        setLanguageByDefault();
        return abstractLanguage;
    }

    public void setLanguageByDefault(LaguageAvailable language= LaguageAvailable.SPAIN) {
        switch (language)
        {
            case LaguageAvailable.SPAIN:
            default:
                abstractLanguage = new SpainLanguage();
                break;
        }
    }
}

