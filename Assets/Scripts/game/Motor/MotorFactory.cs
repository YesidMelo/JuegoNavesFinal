public class MotorFactory 
{
    public AbstractMotor getMotor(Motor motorSelected) {
        switch (motorSelected) {
            case Motor.TYPE_2:
                return new MotorType2();
            case Motor.TYPE_3:
                return new MotorType3();
            case Motor.TYPE_4:
                return new MotorType4();
            case Motor.TYPE_5:
                return new MotorType5();
            case Motor.TYPE_1:
            default:
                return new MotorType1();
        }
    }
}
