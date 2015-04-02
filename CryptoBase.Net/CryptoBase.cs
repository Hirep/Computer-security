using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
