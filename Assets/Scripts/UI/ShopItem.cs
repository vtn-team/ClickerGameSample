using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Text _name;
    [SerializeField] UnityEngine.UI.Text _cost;
    [SerializeField] UnityEngine.UI.Text _num;

    int _itemNum = 0;
    UnityEngine.UI.Button _button;
    ShopItemTable _item;
    FactoryData _data;

    public void Setup(ShopItemTable item)
    {
        _item = item;
        _button = GetComponent<UnityEngine.UI.Button>();
        _button.onClick.AddListener(() =>
        {
            if (Cost() > GameManager.CookieNum) return;

            GameManager.Purchase(_item, Cost());
            UpdateItem();
        });

        UpdateItem();
    }

    int Cost()
    {
        return Mathf.FloorToInt(_item.Cost * (1.0f + (float)(_itemNum/10.0f)));
    }

    public void UpdateItem()
    {
        _name.text = _item.Name;

        if (_item.Type == ItemType.Factory)
        {
            _itemNum = GameManager.Factory.GetLevel(_item.TargetId);
            _num.text = _itemNum.ToString();
        }
        else
        {
            _num.text = "";
        }

        _cost.text = string.Format("Cost:{0}", CostStringConverter.Convert(Cost()));
    }

    private void Update()
    {
        CheckPerchase();
    }

    void CheckPerchase()
    {
        if (Cost() > GameManager.CookieNum)
        {
            _cost.color = Color.red;
        }
        else
        {
            _cost.color = Color.black;
        }
    }
}
