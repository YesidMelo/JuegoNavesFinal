using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerBar : MonoBehaviour
{
    public float maxBar = 1000;
    public float currentBar = 1000;
    
    [Range(1,100)]
    public int valueDecreaseBar = 1;
    [Range(1, 100)]
    public int valueIncreaseBar = 1;
    public bool boolDecreaseBar = false;
    public bool boolIncreaseBar = false;

    public GameObject currentFill;
    

    // Update is called once per frame
    void Update()
    {
        if (boolDecreaseBar) {
            boolDecreaseBar = false;
            decreaseBar(valueDecreaseBar);
        }

        if (boolIncreaseBar) {
            boolIncreaseBar = false;
            increaseBar(valueIncreaseBar);
        }
        
    }

    public void decreaseBar(float decrease = 1)
    {
        if (currentFill == null) return;

        currentBar = currentBar - decrease;
        if (currentBar < 0) {
            currentBar = 0;
        }
        float percentage = currentBar / maxBar;
        currentFill.transform.localScale = new Vector3(percentage, 1, 1);
    }

    public void increaseBar(float decrease = 1)
    {
        if (currentFill == null) return;

        currentBar = currentBar + decrease;
        if (currentBar > maxBar)
        {
            currentBar = maxBar;
        }
        float percentage = currentBar / maxBar;
        currentFill.transform.localScale = new Vector3(percentage, 1, 1);
    }
}
