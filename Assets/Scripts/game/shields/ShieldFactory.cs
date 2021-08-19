public class ShieldFactory 
{
    public AbstractShield getShield(Shield shieldSelected) { 
        switch(shieldSelected)
        {
            case Shield.TYPE_2:
                return new ShieldType2();
            case Shield.TYPE_3:
                return new ShieldType3();
            case Shield.TYPE_4:
                return new ShieldType4();
            case Shield.TYPE_5:
                return new ShieldType5();
            case Shield.TYPE_1:
            default:
                return new ShieldType1();
        }
    }
}
