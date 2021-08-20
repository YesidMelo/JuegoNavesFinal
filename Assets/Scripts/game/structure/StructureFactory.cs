public class StructureFactory 
{
    public AbstractStructure getStructure(Structure currentStructure) {
        switch (currentStructure) {
            case Structure.TYPE_2:
                return new StructureType2();
            case Structure.TYPE_3:
                return new StructureType3();
            case Structure.TYPE_4:
                return new StructureType4();
            case Structure.TYPE_5:
                return new StructureType5();
            case Structure.TYPE_1:
            default:
                return new StructureType1();
        }
    }
}
