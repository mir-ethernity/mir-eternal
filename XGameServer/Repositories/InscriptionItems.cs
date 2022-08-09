using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Templates
{
    public class InscriptionItems
    {
        public static Dictionary<byte, InscriptionItems> DataSheet;
        public static InscriptionItems[] AllInscriptionItems;

        public byte Id;
        public ItemBackPack Backpack;
        public GameObjectRace[] NeedRace = new GameObjectRace[0];
        public GameObjectGender? NeedGender;
        public ushort? Quantity;
        public int ItemId;

        public static void LoadData()
        {
            DataSheet = new Dictionary<byte, InscriptionItems>();
            string path = Path.Combine(Config.GameDataPath, "System", "Items", "Inscription");
            AllInscriptionItems = Serializer.Deserialize<InscriptionItems>(path);
            foreach (var inscriptionItem in AllInscriptionItems)
                DataSheet.Add(inscriptionItem.Id, inscriptionItem);
        }
    }
}
