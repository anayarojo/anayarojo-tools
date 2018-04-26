using System.Text;

namespace AnayaRojo.Tools.Extensions.Security
{
    /// <summary>
    ///     Extensión para obtener Checksum Crc32
    /// </summary>
    /// <remarks>
    ///     Raul Anaya, 02/01/2018
    /// </remarks>
    public static class Crc32Extension
    {
        /// <summary>
        ///     Crc32
        /// </summary>
        private static Crc32 mObjCrc32;

        /// <summary>
        ///     Constructor
        /// </summary>
        static Crc32Extension()
        {
            mObjCrc32 = new Crc32();
        }

        /// <summary>
        ///     Método para obtener checksum
        /// </summary>
        /// <param name="pStrText">
        ///     Texto
        /// </param>
        /// <returns>
        ///     Checksum
        /// </returns>
        public static string ComputeChecksum(this string pStrText)
        {
            string lStrResult = string.Empty;

            foreach (byte lBytHash in pStrText.ComputeChecksumBytes())
            {
                lStrResult += lBytHash.ToString("x2");
            }

            return lStrResult;
        }

        /// <summary>
        ///     Método para obtener checksum
        /// </summary>
        /// <param name="pStrText">
        ///     Texto
        /// </param>
        /// <returns>
        ///     Checksum en arreglo de bytes
        /// </returns>
        public static byte[] ComputeChecksumBytes(this string pStrText)
        {
            byte[] lArrBytToHash = UTF8Encoding.UTF8.GetBytes(pStrText);
            return mObjCrc32.ComputeHash(lArrBytToHash);
        }
    }
}
