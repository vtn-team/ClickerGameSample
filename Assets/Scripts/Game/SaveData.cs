using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class FactoryData
{
    public int Id;
    public int Level;
}

[Serializable]
public class UpgradeData
{
    public int Id;
}

[Serializable]
public class SaveData
{
    public int GameVersion = 1;
    public int CookieNum = 0;
    public List<FactoryData> Factory = new List<FactoryData>(); //記録されたFactoryは保有している
    public List<UpgradeData> Upgrade = new List<UpgradeData>(); //記録されたUpgradeは保有している
}
