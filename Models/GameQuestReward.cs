using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class GameQuestReward
    {
        public QuestRewardType Type { get; set; }
        public int Id { get; set; }
        public int Count { get; set; }
        public bool Bind { get; set; }
    }
}
