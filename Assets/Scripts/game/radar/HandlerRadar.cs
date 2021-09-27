using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerRadarDelegate {
    void enterGameObject(Collider2D collision);
    void exitGameObject(Collider2D collision);
}

public class HandlerRadar : MonoBehaviour
{
    private HandlerRadarDelegate _myDelegate;
    public HandlerRadarDelegate myDelegate { set { _myDelegate = value; } }
    public Radar currentRadar = Radar.TYPE_1;
    public AbstractRadar radarType1Enemies;
    //TODO(YesidMelo): implementar los diferentes radares en versiones posteriores
    public AbstractRadar radarType2;
    public AbstractRadar radarType3;
    public AbstractRadar radarType4;
    public AbstractRadar radarType5;

    public List<GameObject> objetives {
        get {
            switch (currentRadar) {
                case Radar.TYPE_2:
                    return radarType2.listObjetives;
                case Radar.TYPE_3:
                    return radarType3.listObjetives;
                case Radar.TYPE_4:
                    return radarType4.listObjetives;
                case Radar.TYPE_5:
                    return radarType5.listObjetives;
                case Radar.TYPE_1:
                default:
                    return radarType1Enemies.listObjetives;
            }
        }
    }

    public GameObject currentObjetive {
        get {
            switch (currentRadar)
            {
                case Radar.TYPE_2:
                    return radarType2.currentObjetive;
                case Radar.TYPE_3:
                    return radarType3.currentObjetive;
                case Radar.TYPE_4:
                    return radarType4.currentObjetive;
                case Radar.TYPE_5:
                    return radarType5.currentObjetive;
                case Radar.TYPE_1:
                default:
                    return radarType1Enemies.currentObjetive;
            }
        }
    }

    public void changeEnemy() {
        switch (currentRadar)
        {
            case Radar.TYPE_2:
                radarType2.changeObjetive();
                return;
            case Radar.TYPE_3:
                radarType3.changeObjetive();
                return;
            case Radar.TYPE_4:
                radarType4.changeObjetive();
                return;
            case Radar.TYPE_5:
                radarType5.changeObjetive();
                return;
            case Radar.TYPE_1:
            default:
                radarType1Enemies.changeObjetive();
                return;
        }
    }

    private void Awake() => createRadar();

    private void Start()
    {
        radarType1Enemies.currentSideGameObject = transform.parent.parent.name;
        radarType2.currentSideGameObject = transform.parent.parent.name;
        radarType3.currentSideGameObject = transform.parent.parent.name;
        radarType4.currentSideGameObject = transform.parent.parent.name;
        radarType5.currentSideGameObject = transform.parent.parent.name;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        radarType1Enemies.addObjetive(collision);
        radarType2.addObjetive(collision);
        radarType3.addObjetive(collision);
        radarType4.addObjetive(collision);
        radarType5.addObjetive(collision);
        _myDelegate.enterGameObject(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        radarType1Enemies.removeEnemy(collision);
        radarType2.removeEnemy(collision);
        radarType3.removeEnemy(collision);
        radarType4.removeEnemy(collision);
        radarType5.removeEnemy(collision);
        _myDelegate.enterGameObject(collision);
    }

    //public methods
    public void updateRadar(Radar currentRadar) {
        this.currentRadar = currentRadar;
    }

    // private methods

    private void createRadar() {
        radarType1Enemies = (new RadarFactory()).getRadar(Radar.TYPE_1);
        radarType2 = (new RadarFactory()).getRadar(Radar.TYPE_2);
        radarType3 = (new RadarFactory()).getRadar(Radar.TYPE_3);
        radarType4 = (new RadarFactory()).getRadar(Radar.TYPE_4);
        radarType5 = (new RadarFactory()).getRadar(Radar.TYPE_5);
    }
}
