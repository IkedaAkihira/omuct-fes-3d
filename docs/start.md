# 準備
githubアカウントがあって、gitの環境構築をしてあること前提で話すよ。
# 環境構築のみをやった人へ
コマンドプロンプトを開いて、任意のフォルダに移動してください。
次に、
```
$ git clone https://github.com/IkedaAkihira/omuct-fes-3d.git
```
としてください。
# 一回cloneした人へ
コマンドプロンプトで .../omuct-fes-3dに移動し、以下のコマンドを実行してください。
```
$ git pull
```
これは、github上にある最新のやつを引っ張ってきます。

# ここから共通
コマンドプロンプトで .../omuct-fes-3dに移動し、以下のコマンドを実行してください。
```
$ git branch 実装する機能の名前
```
今はあんまりなにも考えないでください。  
毒攻撃を実装する場合は
```
$ git branch poison
```
とかでいいと思います。
次に、Unity Hubで、さっきのフォルダ/omuct-fes-3d/Omuct Fes 3Dを開くと、プロジェクトを開けると思います。
ここからは適宜ドキュメントを参照して作業を進めてください。
## ドキュメントたち
* [アイテムを作ろう](./how-to-add-item.md)
# ある程度作業が進んだら
ある程度作業が進んだら、同じディレクトリで、
```
$ git add *
$ git commit -m "作業の説明(必須)"
$ git push
```
を行ってください。
作業をgithub上にアップするやつです。
# 作業が形になったら
作業が完了、一旦形になったら、[ここ](https://github.com/IkedaAkihira/omuct-fes-3d)を開いてください。  
すると、黄色い枠内にCompareなんたら、みたいなボタンがあると思うので、押してください。
![プレゼンテーション1](https://user-images.githubusercontent.com/91947939/195361751-f5e78223-fcce-4e79-98f8-aa76ffe44f13.png)
Leave Commentの欄に説明を入力して、Create Pull Requestを押してください。  
これで、"プルリク"が作成できます。これは、作業の完了を報告するやつです。説明には[MarkDown記法](https://qiita.com/tbpgr/items/989c6badefff69377da7)が使え、画像が盛り込めたりするので、適宜活用してください。  
ここまでやってくれたら、俺がコードを確認して、統合します。

説明くそ適当なので、わからんことは適宜聞くなり調べたりしてください。
