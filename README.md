# HoloMania - Sample Code
HoloHack2021 で作成したHololens 2 向け音楽ゲーム「HoloMania」のソースコード  

### ゲーム概要
画面奥から音楽に合わせて飛んでくる敵機をタッチして撃破します

### ゲームプレイ中のようす
<img width="300" alt="スクリーンショット 2023-11-19 5 08 56" src="https://github.com/tamaUdon/HoloMania/assets/47604161/f6420c4c-c47d-468a-a2d3-9ed44f3bb781">

<img width=" 300" alt="スクリーンショット 2023-11-19 5 13 07" src="https://github.com/tamaUdon/HoloMania/assets/47604161/f7468bac-4d21-4588-af19-79e02bc4df2b">

### スクリプトの解説
Assets/Script

- Cube.cs ... レーンに沿って飛んでくるGameObjectにアタッチするスクリプト
- LaneAnimation.cs ... レーンを2色に光らせるスクリプト（DOTween使用）
- Spawner.cs ... レーンと飛んでくるGameObjectを生成・管理するスクリプト

MRTK/Extensions/HandPhysicsService 

- JointKinematicBody.cs ... MRTKのスクリプトにOnTriggerEnterを追記したもの（衝突時のエフェクト表示用）　　

### Appendix
制作時のブログ: https://tama-ud.hatenablog.com/entry/2021/03/16/170939

