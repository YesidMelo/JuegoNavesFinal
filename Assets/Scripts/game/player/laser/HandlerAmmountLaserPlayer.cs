using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerAmmountLaserPlayer : MonoBehaviour
{

    public LaserPlayer laserSelected = LaserPlayer.TYPE_1;
    public SpriteRenderer spriteRenderer;
    public Sprite laserType1;
    public Sprite laserType2;
    public Sprite laserType3;
    public Sprite laserType4;
    public Sprite laserType5;
    private DetailLaserPlayer _detailLaser;
    private StatusGameIsGameInPauseUseCase isGameInPauseUseCase = new StatusGameIsGameInPauseUseCaseImpl();
    
    // Update is called once per frame
    void Update()
    {
        if (isGameInPauseUseCase.invoke()) return;
        updateRenderer();
        moveLaser();
    }

    //public methods
    public void updateDetailLaser(DetailLaserPlayer detailLaserPlayer) => _detailLaser = detailLaserPlayer;

    //private methods

    private void updateRenderer() {
        Sprite sprite;
        switch (laserSelected)
        {
            case LaserPlayer.TYPE_2:
                sprite = laserType2;
                break;
            case LaserPlayer.TYPE_3:
                sprite = laserType3;
                break;
            case LaserPlayer.TYPE_4:
                sprite = laserType4;
                break;
            case LaserPlayer.TYPE_5:
                sprite = laserType5;
                break;
            case LaserPlayer.TYPE_1:
            default:
                sprite = laserType1;
                break;
        }
        spriteRenderer.sprite = sprite;
    }

    private void moveLaser() {
        transform.Translate(Vector2.right * Constants.speedLaser * Time.deltaTime);
    }

    //get and sets
    public DetailLaserPlayer detailLaser {
        get => _detailLaser;
    }
}
