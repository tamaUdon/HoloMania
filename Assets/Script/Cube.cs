using Microsoft.MixedReality.Toolkit;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public Vector3 playerpos;
    public GameObject effectExplosion; // オブジェクトに触れた時のパーティクル
    public GameObject touchEffect; // 一定以上ポイントがたまったら生成する背景のパーティクル
    private float tmpTarget;
    private bool isTrigger = false;
    private Vector3 targetPoint;
    private int counter = 0;
    private GameObject effect;

    // Start is called before the first frame update
    void Start()
    {
        playerpos = CoreServices.InputSystem.GazeProvider.GazeOrigin;
        tmpTarget = UnityEngine.Random.Range(-2, 2);

        var diff = -3.0f;
        if((tmpTarget+2)%2==1)
        {
            diff = -4.0f;
        }
        this.targetPoint = new Vector3(tmpTarget*3, diff, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // targetに向かう
        this.transform.position = Vector3.MoveTowards(
           this.transform.position,
           this.targetPoint,
           1.1f);

        // 一定の位置に達したらGameObjectを破棄する
        if (this.transform.position.z == 0)
        {
            Destroy(this.gameObject);
        }
    }

    // 手との衝突判定
    void OnTriggerEnter(Collider other)
    {
        if (isTrigger)
        {
            return;
        }

        isTrigger = true;
        if (other.gameObject.tag.Contains("Player"))
        {
            PointCounter.AddPoint(50); // ポイント加算

            if (counter%1000==0) // 1000ポイントごとに背景のパーティクルを増やす
            {
                Instantiate(touchEffect, this.transform.position, Quaternion.identity);
            }

            counter++;
        }
        isTrigger = false;
    }
}
