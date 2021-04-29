using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneAnimation : MonoBehaviour
{
    public Renderer rendererComponent;
    // Start is called before the first frame update
    void Start()
    {
        // Minute=60/BPM=105*2
        this.rendererComponent.material.DOColor(Color.red, 0.2857f).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
