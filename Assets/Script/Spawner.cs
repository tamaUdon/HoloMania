using Microsoft.MixedReality.Toolkit;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] cubes;
    public Transform[] points;
    private float beat = 1;
    public GameObject[] lanes; // レーン
    public GameObject resultText; // リザルトの表示
    public GameObject calorieText; // 消費カロリーの表示
    public GameObject clearEffect; // クリア時の花火エフェクト
    public GameObject retryButton; // リトライボタン
    private float timer;
    private System.Timers.Timer aTimer;
    private bool terminated;

    // Start is called before the first frame update
    void Start()
    {
        terminated = false;

        var playerpos = CoreServices.InputSystem.GazeProvider.GazeOrigin;
        var cnt = 0;

        // 約4分後(曲の終わりごろ)に画面遷移、オブジェクト生成をやめる
        Invoke(nameof(StopCreateCube), 60.0f*3.8f);

        // レーンを作る
        foreach (int i in Enumerable.Range(-2, 5))
        {
            // レーンの形状を変えたいときはlane[]にお好みのGameObjectを入れてください
            GameObject lane = Instantiate(
                lanes[cnt], points[0]); 

            lane.transform.localPosition = new Vector3(0, 15, 100);

            // 2点間の距離を算出してサイズを調整
            float yPointDiff = -3.0f;
            if((i+2)%2==1)
            {
                // 1,3,5番目のレーンだけ到達する位置の高さを変更
                yPointDiff = -4.0f;
            }

            float distance = Vector3.Distance(lane.transform.localPosition, new Vector3(i*3,yPointDiff, -1));

            // Rotationの制御
            lane.transform.localScale = new Vector3(0.1f, 0.1f, distance * 3);
            var rotate = Quaternion.LookRotation(
                lane.transform.localPosition - new Vector3(i * 3, yPointDiff, 0), Vector3.forward);
            lane.transform.rotation = rotate;
            
            cnt++;
        }
    }

    /// <summary>
    /// Cubeの生成をやめる
    /// </summary>
    public void StopCreateCube()
    {
        terminated = true;
        Invoke(nameof(MoveToResult), 10.0f);
    }

    /// <summary>
    /// 結果を表示する
    /// </summary>
    public void MoveToResult()
    {
       
        var text = "FAILED";
        if (PointCounter.currentPoints > 20000)
        {
            text = "CLEAR!";
            Instantiate(clearEffect, new Vector3(0, 0, 5), Quaternion.identity);
        }
        
        resultText.GetComponent<TextMesh>().text = text;
        resultText.transform.localScale = new Vector3(1, 1, 1);
        calorieText.GetComponent<TextMesh>().text = "13.2kcal"; // 今は固定表示
        calorieText.transform.localScale = new Vector3(1, 1, 1);
        retryButton.transform.localScale = new Vector3(40, 40, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (terminated)
        {
            return;
        }

        if (timer > beat)
        {
                GameObject cube = Instantiate(
                    cubes[UnityEngine.Random.Range(0, 3)]);
                cube.transform.localPosition = new Vector3(0, 22.5f, 150);
                cube.transform.Rotate(new Vector3(0, 180, 0));

            timer -= beat;
        }

        timer += Time.deltaTime;
    }

    
}
