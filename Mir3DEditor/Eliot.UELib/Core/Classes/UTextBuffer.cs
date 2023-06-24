namespace UELib.Core
{
    [UnrealRegisterClass]
    public partial class UTextBuffer : UObject
    {
        #region Serialized Members

        public uint Top;
        public uint Pos;
        
        public string ScriptText;

        #endregion

        #region Constructors

        public UTextBuffer()
        {
            ShouldDeserializeOnDemand = true;
        }

        protected override void Deserialize()
        {
            base.Deserialize();
            
            Top = _Buffer.ReadUInt32();
            Pos = _Buffer.ReadUInt32();
            ScriptText = _Buffer.ReadText();
        }

        #endregion
    }
}