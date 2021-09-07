# HoloMania - Sample Code

HoloHack2021で作成したHololens 2 用音楽ゲーム「HoloMania」のサンプルコードです。  
概要: https://tama-ud.hatenablog.com/entry/2021/03/16/170939


### Assets/Script 以下

Cube.cs ... レーンに沿って飛んでくるGameObjectにアタッチするスクリプト

LaneAnimation.cs ... レーンを2色に光らせるスクリプト（DOTween使用）

Spawner.cs ... レーンと飛んでくるGameObjectを生成・管理するスクリプト


### MRTK/Extensions/HandPhysicsService 以下

JointKinematicBody.cs ... MRTKのスクリプトにOnTriggerEnterを追記したもの（衝突時のエフェクト表示用）　　



