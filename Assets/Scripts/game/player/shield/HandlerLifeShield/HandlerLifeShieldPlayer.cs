using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HandlerLifeShieldPlayer : MonoBehaviour, HandlerLifeShieldPlayerViewModelDelegate,
    ListenerShieldPlayerDelegate
{
    public HandlerShieldPlayer handlerShieldPlayer;
    public List<ListenerShieldPlayer> shieldsAvailable;

    private HandlerLifeShieldPlayerViewModel viewModel = new HandlerLifeShieldPlayerViewModelImpl();
    private ListenerShieldPlayer _currentListenerShieldPlayer;

    private void Awake()
    {
        viewModel.myDelegate = this;
        setDelegatesInShield();
    }

    //public methods
    //private methods
    private void setDelegatesInShield() {
        if (shieldsAvailable == null || shieldsAvailable.Count == 0) return;
        foreach (ListenerShieldPlayer listener in shieldsAvailable) {
            listener.myDelegte = this;
            if (listener.currentSpacecraft != viewModel.currentStructure) {
                _currentListenerShieldPlayer.gameObject.hidden();
                continue; 
            }
            _currentListenerShieldPlayer = listener;
            _currentListenerShieldPlayer.gameObject.show();
        }
    }

    //ui methods
    //delegates

    //ListenerShieldPlayerDelegate methods
    public void OnTriggerEnter2DDelegate(Collider2D collision)
    {
        if (!collision.name.Contains(Constants.nameAmmunitionLaserEnemy)) return;
        viewModel.removeLife(collision);
        Destroy(collision.gameObject);
    }

    public void OnTriggerExit2DDelegate(Collider2D collision) {}


}
