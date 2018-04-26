using System;
using System.Security.Cryptography;
using System.Text;

namespace AnayaRojo.Tools.Extensions.Security
{
    /// <summary>
    ///     Extensión para encriptar y desencriptar
    /// </summary>
    /// <remarks>
    ///     Raul Anaya, 02/01/2018
    /// </remarks>
    public static class EncryptionExtension
    {
        /// <summary>
        ///     Método para encriptar un texto
        /// </summary>
        /// <param name="pStrDecoded">
        ///     Texto desencriptado
        /// </param>
        /// <param name="pStrKey">
        ///     Contraseña
        /// </param>
        /// <returns>
        ///     Texto encriptado
        /// </returns>
        public static string Encode(this string pStrDecoded, string pStrKey)
        {
            //arreglo de bytes donde guardaremos la llave
            byte[] keyArray;

            //arreglo de bytes donde guardaremos el texto
            //que vamos a encriptar
            byte[] Arreglo_a_Cifrar =
            UTF8Encoding.UTF8.GetBytes(pStrDecoded);

            //se utilizan las clases de encriptación
            //provistas por el Framework
            //Algoritmo MD5
            MD5CryptoServiceProvider hashmd5 =
            new MD5CryptoServiceProvider();
            //se guarda la llave para que se le realice
            //hashing
            keyArray = hashmd5.ComputeHash(
            UTF8Encoding.UTF8.GetBytes(pStrKey));

            hashmd5.Clear();

            //Algoritmo 3DAS
            TripleDESCryptoServiceProvider tdes =
            new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            //se empieza con la transformación de la cadena
            ICryptoTransform cTransform =
            tdes.CreateEncryptor();

            //arreglo de bytes donde se guarda la
            //cadena cifrada
            byte[] ArrayResultado =
            cTransform.TransformFinalBlock(Arreglo_a_Cifrar,
            0, Arreglo_a_Cifrar.Length);

            tdes.Clear();

            //se regresa el resultado en forma de una cadena
            return Convert.ToBase64String(ArrayResultado,
            0, ArrayResultado.Length);
        }

        /// <summary>
        ///     Método para desencriptar un texto
        /// </summary>
        /// <param name="pStrEncoded">
        ///     Texto encriptado
        /// </param>
        /// <param name="pStrKey">
        ///     Contraseña
        /// </param>
        /// <returns>
        ///     Texto desencriptado
        /// </returns>
        public static string Decode(string pStrEncoded, string pStrKey)
        {
            //arreglo de bytes donde guardaremos la llave
            byte[] keyArray;

            //convierte el texto en una secuencia de bytes
            byte[] Array_a_Descifrar =
            Convert.FromBase64String(pStrEncoded);

            //se llama a las clases que tienen los algoritmos
            //de encriptación se le aplica hashing
            //algoritmo MD5
            MD5CryptoServiceProvider hashmd5 =
            new MD5CryptoServiceProvider();

            keyArray = hashmd5.ComputeHash(
            UTF8Encoding.UTF8.GetBytes(pStrKey));

            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes =
            new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform =
            tdes.CreateDecryptor();

            byte[] resultArray =
            cTransform.TransformFinalBlock(Array_a_Descifrar,
            0, Array_a_Descifrar.Length);

            tdes.Clear();

            //Se regresa en forma de cadena
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }
}
