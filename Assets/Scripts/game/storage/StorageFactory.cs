public class StorageFactory {

    public AbstractStorage getStorage(Storage storage) {
        switch (storage) {
            case Storage.TYPE_2:
                return new StorageType2();
            case Storage.TYPE_3:
                return new StorageType3();
            case Storage.TYPE_4:
                return new StorageType4();
            case Storage.TYPE_5:
                return new StorageType5();
            case Storage.TYPE_1:
            default:
                return new StorageType1();
        }
    }

}