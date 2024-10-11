using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplainUI : MonoBehaviour
{
    [SerializeField] Text dataName;
    [SerializeField] Image iconImage;
    [SerializeField] Text explainData;

    public void SetExplainUI(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return;
        }
        GameDataDB db = GameManager.instance.gameDB.GetGameData(id);
        dataName.text =db.name;
        iconImage.sprite = Resources.Load<Sprite>(db.iconPath);
        explainData.text = db.explain;
    }
}
