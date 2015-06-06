using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace CryptoBase
{
    public interface ICipher
    {
        String Encrypt(String msg);
        String Decrypt(String msg);
    }
    
    public class BookCipher: ICipher
    {
        private readonly String Key;    /* Since format allows only two digit coordinates for key elements,
                                         * max key length must be 99*99 = 9801 characters */
        private readonly Char[,] KeyMatrix;
        private bool validKey(String message,String key)
        {
            foreach (char letter in message)
            {
                if (!key.Contains(letter))
                    return false;
            }
            return true;
        }
        public BookCipher(String key)
        {
            this.Key = key;

            int sizeOfKeyMatrix = Convert.ToInt32(Math.Sqrt(Key.Length))+1;    // Calc size of KeyMatr, +1 for sure
            KeyMatrix = new Char[sizeOfKeyMatrix, sizeOfKeyMatrix];
            int iterator = 0;
            for (int i = 0; (i < KeyMatrix.GetLength(1)) && iterator<Key.Length; i++)   // KeyMatrix initialization with Key symbols
            {
                for (int j = 0; j < KeyMatrix.GetLength(1) && iterator < Key.Length; j++)
                {
                    KeyMatrix[i,j] = Key[iterator];
                    iterator++;
                }
            }
        }
        public String Encrypt(String message)
        {
            if (!validKey(message, Key))
            {
                return "Error code alpha-one";
            }
            String EText = null;
            foreach (Char letter in message)
            {
                bool letterFound = false;   // breaks the cycle
                for (int i = 0; i < KeyMatrix.GetLength(1) && !letterFound; i++)
                {
                    for (int j = 0; j < KeyMatrix.GetLength(1) && !letterFound; j++)
                    {
                        if (letter == KeyMatrix[i, j])
                        {
                            EText += String.Format("{0:00}{1:00}", i, j);   // {n:00} format results bad behaviour for long keys(over9800)
                            letterFound = true;
                        }
                    }
                }
            }
            return EText;
        }
        public String Decrypt(String message)
        {
            String PText = null;
            for (int i = 0; i < message.Length; i += 4)  // deal with blocks of 4 digits
            {
                PText += KeyMatrix[Convert.ToInt32(message.Substring(i, 2)),
                                Convert.ToInt32(message.Substring(i + 2, 2))];
            }
            return PText;
        }
    }

    public class DES : ICipher
    {
        private readonly String message;
        private String fileInput, fileOutput;
        private FileStream streamInput, streamOutput;
        private DESCryptoServiceProvider cryptic = new DESCryptoServiceProvider();
        
        public DES(String Key, String InitializationVector, String fileInput, String fileOutput)
        {
            this.fileInput = fileInput;
            this.fileOutput = fileOutput;
            cryptic.Key = UTF8Encoding.UTF8.GetBytes(Key);
            cryptic.IV = UTF8Encoding.UTF8.GetBytes(InitializationVector);
            streamInput = new FileStream(this.fileInput, FileMode.Open, FileAccess.Read);
            streamOutput = new FileStream(this.fileOutput, FileMode.Open, FileAccess.ReadWrite);
        }
        public String Encrypt(String filePathInput)
        {
            CryptoStream CS = new CryptoStream(streamOutput, cryptic.CreateEncryptor(), CryptoStreamMode.Write);
            
            byte[] bytearrayinput = new byte[streamInput.Length];
            streamInput.Read(bytearrayinput, 0, bytearrayinput.Length);
            CS.Write(bytearrayinput, 0, bytearrayinput.Length);
            CS.Close();
            streamInput.Close();
            streamOutput.Close();

            return "0";
        }
        public String Decrypt(String filePathInput)
        {
            CryptoStream CS = new CryptoStream(streamInput, cryptic.CreateDecryptor(), CryptoStreamMode.Read);
            
            byte[] bytearrayinput = new byte[streamInput.Length];
            CS.Read(bytearrayinput, 0, bytearrayinput.Length);
            streamOutput.Write(bytearrayinput, 0, bytearrayinput.Length);
            CS.Close();
            streamInput.Close();
            streamOutput.Close();
            
            return "0";
        }
    }

    public class Knapsack : ICipher
    {
        public int[] openKey;
        private int q;
        private int w;
        private int r;

        public int[] secretKey;

        public Knapsack(int[] openKey, int w, Int32 q, Int32 r)
        {
            this.openKey = new int[openKey.Length];
            Array.Copy(openKey, this.openKey, openKey.Length);

            this.w = w;
            this.r = r;
            this.q = q;
        }

        private Int32 ModuleInverse(int value, int mod)
        {
            for (int i = 0; i <= mod; i++)
            {
                if ((value * i) % mod == 1)
                    return i;
            }

            return -1;
        }

        public string Encrypt(string plainText)
        {
            var bytes = UTF8Encoding.Default.GetBytes(plainText);
            var outBytes = new int[bytes.Length];

            for (int i = 0; i < bytes.Length; i++)
            {
                int sum = 0;
                int c = bytes[i];

                for (int j = openKey.Length - 1; j >= 0; j--)
                {
                    sum += openKey[j] * (c & 1);
                    c = c >> 1;
                }

                outBytes[i] = sum;
            }

            var output = new StringBuilder();
            foreach (var b in outBytes)
                output.Append(b + " ");

            return output.ToString();
        }

        public string Decrypt(string cryptedText)
        {
            if (secretKey == null)
                throw new Exception("No secret key!");

            var parts = cryptedText.Trim(' ').Split(' ').Select(Int32.Parse).ToList();
            var output = new StringBuilder(parts.Count);

            var inverse = ModuleInverse(r, q);

            for (int i = 0; i < parts.Count; i++)
            {
                var m = parts[i] * inverse % q;
                var ans = 0;

                for (int j = secretKey.Length - 1; j >= 0; j--)
                {
                    ans <<= 1;
                    if (m >= secretKey[j])
                    {
                        m -= secretKey[j];
                        ans |= 1;
                    }
                }

                var symbols = (Convert.ToString(ans, 2)).PadLeft(secretKey.Length, '0').ToCharArray();
                Array.Reverse(symbols);
                ans = Convert.ToInt32(new String(symbols), 2);
                //char a = Convert.ToChar(ans);
                char a = UnicodeEncoding.Default.GetChars(new byte[]{(byte)ans})[0];
                output.Append(a);
            }

            return output.ToString();
        }
    }
    
    public class DiffieHellmanProtocol: ICipher
    {
        #region defaultCode
        //static CngKey aliceCngKey = CngKey.Create(CngAlgorithm.ECDiffieHellmanP256);    // 1. Аліса створює сховище ключів
        //
        //
        //static byte[] alicePublicKeyBlob = aliceCngKey.Export(CngKeyBlobFormat.EccPublicBlob); //і експортує з нього свій публічний
        //                                                                                //ключ для передачі Бобу
        //
        //static CngKey bobCngKey = CngKey.Create(CngAlgorithm.ECDiffieHellmanP256);  // 2. Боб створює сховище ключів і 
        //
        //static byte[] bobPublicKeyBlob = aliceCngKey.Export(CngKeyBlobFormat.EccPublicBlob);    //експортує з нього свій публічний ключ для передачі Алісі
        //
        //static CngKey bobPubCngKey = CngKey.Import(bobPublicKeyBlob, CngKeyBlobFormat.EccPublicBlob);  // 3. Аліса імпортує публічний ключ Боба в окреме сховище
        //
        //static ECDiffieHellmanCng aliceAlgorithm = new ECDiffieHellmanCng(aliceCngKey); // 4. Аліса створює екземпляр класу ECDiffieHellmanCng
        //                                                                                //з ключами, що беруться з її сховища ключів
        //
        //byte[] aliceKey = aliceAlgorithm.DeriveKeyMaterial(bobPubCngKey);   // 5. Аліса отримує секретний ключ з ключового матеріалу
        //
        //static CngKey alicePubCngKey = CngKey.Import(alicePublicKeyBlob,CngKeyBlobFormat.EccPublicBlob);   // 6. Боб імпортує публічний ключ Аліси
        //                                                                                            //в окреме сховище і використовує його для
        //                                                                                            //отримання секретного ключа з 
        //                                                                                            //ключового матеріалу
        //static ECDiffieHellmanCng bobAlgorithm = new ECDiffieHellmanCng(bobCngKey);
        //byte[] bobKey = bobAlgorithm.DeriveKeyMaterial(alicePubCngKey);
        #endregion

        byte[] bobKey, aliceKey;

        private static string Key;
        private static string IV    = "frasdfgh";
        AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
        


        public DiffieHellmanProtocol()
        {
            ECDiffieHellmanCng alice = new ECDiffieHellmanCng();
            alice.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
            alice.HashAlgorithm = CngAlgorithm.Sha256;

            ECDiffieHellmanCng bob = new ECDiffieHellmanCng();
            bob.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
            bob.HashAlgorithm = CngAlgorithm.Sha256;

            byte[] bobKey = bob.DeriveKeyMaterial(alice.PublicKey);
            byte[] aliceKey = alice.DeriveKeyMaterial(bob.PublicKey);

            aes.BlockSize = 128;
            aes.KeySize = 256;
            
            aes.IV = System.Text.UnicodeEncoding.Unicode.GetBytes(IV);
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;

            foreach (var keyPart in aliceKey)
            {
                Key += Convert.ToString(keyPart);
            };
            var keyForAES = "";
            for (int i = 0; i < 16; i++)
            {
                keyForAES += Key[i];
            }

            aes.Key = System.Text.UnicodeEncoding.Unicode.GetBytes(keyForAES);
        }

        public string getKey()
        {
            return Key;
        }

        public string Encrypt(string text)
        {
            byte[] plaintextbytes = System.Text.UnicodeEncoding.Unicode.GetBytes(text);
            ICryptoTransform crypto = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] encrypted = crypto.TransformFinalBlock(plaintextbytes, 0, plaintextbytes.Length);
            crypto.Dispose();
            return Convert.ToBase64String(encrypted);
        }

        public string Decrypt(string encrypted)
        {
            byte[] encryptedbytes = Convert.FromBase64String(encrypted);
            ICryptoTransform crypto = aes.CreateDecryptor(aes.Key, aes.IV);
            byte[] secret = crypto.TransformFinalBlock(encryptedbytes, 0, encryptedbytes.Length);
            crypto.Dispose();
            return System.Text.UnicodeEncoding.Unicode.GetString(secret);

        }

    }
}
