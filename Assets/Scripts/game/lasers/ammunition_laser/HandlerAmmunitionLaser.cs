using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerAmmunitionLaser : MonoBehaviour
{

    public Laser laserSelected = Laser.TYPE_1;
    public SpriteRenderer spriteRenderer;
    public Sprite laserType1;
    public Sprite laserType2;
    public Sprite laserType3;
    public Sprite laserType4;
    public Sprite laserType5;

    private AbstractLaser _finalLaser;

    public AbstractLaser finalLaser { get { return _finalLaser; } }

    // Update is called once per frame
    void Update()
    {
        updateRenderer();
        transform.parent.transform.Translate(Vector2.up * Constants.speedLaser * Time.deltaTime);
    }

    // public methods
    public void changeAmmountLaser(AbstractLaser laser) {
        _finalLaser = laser;
    }

    // private methods
    private void updateRenderer() {
        Sprite sprite;
        switch (laserSelected) {
            case Laser.TYPE_2:
                sprite = laserType2;
                break;
            case Laser.TYPE_3:
                sprite = laserType3;
                break;
            case Laser.TYPE_4:
                sprite = laserType4;
                break;
            case Laser.TYPE_5:
                sprite = laserType5;
                break;
            case Laser.TYPE_1:
            default:
                sprite = laserType1;
                break;
        }
        spriteRenderer.sprite = sprite;
    }
}
