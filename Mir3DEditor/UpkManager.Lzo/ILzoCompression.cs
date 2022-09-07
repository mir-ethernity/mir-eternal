using System.Threading.Tasks;


namespace UpkManager.Lzo {

  public interface ILzoCompression {

    string Version { get; }

    string VersionDate { get; }

    Task<byte[]> Compress(byte[] source);

    Task Decompress(byte[] Source, byte[] Destination);

  }

}
