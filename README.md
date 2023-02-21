# HoloMania - Sample Code

HoloHack2021で作成したHololens 2 用音楽ゲーム「HoloMania」のサンプルコードです。  
概要: https://tama-ud.hatenablog.com/entry/2021/03/16/170939


### 遊んでみた動画
<blockquote class="twitter-tweet"><p lang="ja" dir="ltr">実際に遊んでみた動画はこちら👇 <a href="https://t.co/aEV8HW2W3X">pic.twitter.com/aEV8HW2W3X</a></p>&mdash; carima (@tama_ud) <a href="https://twitter.com/tama_ud/status/1371022773766660098?ref_src=twsrc%5Etfw">March 14, 2021</a></blockquote>

### Assets/Script 以下

Cube.cs ... レーンに沿って飛んでくるGameObjectにアタッチするスクリプト

LaneAnimation.cs ... レーンを2色に光らせるスクリプト（DOTween使用）

Spawner.cs ... レーンと飛んでくるGameObjectを生成・管理するスクリプト


### MRTK/Extensions/HandPhysicsService 以下

JointKinematicBody.cs ... MRTKのスクリプトにOnTriggerEnterを追記したもの（衝突時のエフェクト表示用）　　



