public interface LaguajeCache { 
    AbstractLanguage currentLangaje { get; }
    void updateCurrentLanguaje(LaguageAvailable laguage);
}

public class LaguageCacheImpl : LaguajeCache
{
    // static
    private static LaguageCacheImpl instance;

    public static LaguageCacheImpl getInstance() {
        if (instance == null) {
            instance = new LaguageCacheImpl();
        }
        return instance;
    }

    //class

    private LanguageFactory _languageFactory;
    private AbstractLanguage _currentLanguage;


    private LaguageCacheImpl() {
        _languageFactory = new LanguageFactory();
        _currentLanguage = _languageFactory.getLanguageSelected();
    }

    public AbstractLanguage currentLangaje => _currentLanguage;
    public void updateCurrentLanguaje(LaguageAvailable languaje) => _languageFactory.setLanguageByDefault(languaje);

}