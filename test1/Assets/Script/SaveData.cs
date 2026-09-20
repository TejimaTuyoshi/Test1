using System.IO;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public ScoreData data;
    string filepath;
    string fileName = "Savedata.json";


    void Awake()
    {
        // パス名取得
        filepath = Application.dataPath + "/" + fileName;

        // ファイルがないとき、ファイル作成
        if (!File.Exists(filepath))
        {
            Save(data);
        }

        // ファイルを読み込んでdataに格納
        data = Load(filepath);
    }

    void Save(ScoreData data)
    {
        string json = JsonUtility.ToJson(data);                 // jsonとして変換
        StreamWriter wr = new StreamWriter(filepath, false);    // ファイル書き込み指定
        wr.WriteLine(json);                                     // json変換した情報を書き込み
        wr.Close();                                             // ファイル閉じる
    }

    ScoreData Load(string path)
    {
        StreamReader rd = new StreamReader(path);               // ファイル読み込み指定
        string json = rd.ReadToEnd();                           // ファイル内容全て読み込む
        rd.Close();                                             // ファイル閉じる
        return JsonUtility.FromJson<ScoreData>(json);            // jsonファイルを型に戻して返す
    }
    void OnDestroy()
    {
        Save(data);
    }
}