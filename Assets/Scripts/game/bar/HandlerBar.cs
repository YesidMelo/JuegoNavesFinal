using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerBar : MonoBehaviour
{
    public float maxBar = 1000;
    public float currentBar = 1000;
    public GameObject currentFill;
    
    // Update is called once per frame
    void Update() => calculateCurrentScale();
    
    private void calculateCurrentScale() {
        if (currentFill == null) return;
        float percentage = currentBar / maxBar;
        currentFill.transform.localScale = new Vector3(percentage, 1, 1);
    }

}
