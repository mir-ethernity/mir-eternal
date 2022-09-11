using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Data
{

    public sealed class HashMonitor<T> : IEnumerable<T>, IEnumerable
    {
        private readonly HashSet<T> v;
        private readonly GameData 对应数据;

        public delegate void 更改委托(List<T> 更改列表);
        public event 更改委托 更改事件;
        public int Count => v.Count;
        public ISet<T> ISet => v;

        public HashMonitor(GameData 数据)
        {
            v = new HashSet<T>();
            对应数据 = 数据;
        }

        public void Clear()
        {
            if (v.Count > 0)
            {
                v.Clear();
                更改事件?.Invoke(v.ToList());
                设置状态();
            }
        }
        public bool Add(T Tv)
        {
            if (v.Add(Tv))
            {
                更改事件?.Invoke(this.v.ToList());
                设置状态();
                return true;
            }
            return false;
        }
        public bool Remove(T Tv)
        {
            if (v.Remove(Tv))
            {
                更改事件?.Invoke(this.v.ToList());
                设置状态();
                return true;
            }
            return false;
        }
        public void QuietlyAdd(T Tv) => v.Add(Tv);
        public bool Contains(T Tv) => v.Contains(Tv);
        public IEnumerator<T> GetEnumerator() => v.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)v).GetEnumerator();
        IEnumerator<T> IEnumerable<T>.GetEnumerator() => v.GetEnumerator();
        public override string ToString() => v?.Count.ToString();
        private void 设置状态()
        {
            if (对应数据 != null)
            {
                对应数据.已经修改 = true;
                GameDataGateway.已经修改 = true;
            }
        }
    }
}
