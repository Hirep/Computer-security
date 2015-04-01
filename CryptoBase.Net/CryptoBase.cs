using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoBase
{
    public interface ICipher
    {
        String Encrypt();
        String Decrypt();
    }
    
    public class BookCipher: ICipher
    {
        private readonly String Message, Key;
        private readonly Char[,] KeyMatrix;
        public BookCipher(String message, String key)
        {
            this.Message = message;
            this.Key = key;

            int sizeOfKeyMatrix = Convert.ToInt32(Math.Sqrt(Key.Length))+1;    // Calc size of KeyMatr, +1 for sure
            KeyMatrix = new Char[sizeOfKeyMatrix, sizeOfKeyMatrix];
            int iterator = 0;
            for (int i = 0; (i < KeyMatrix.GetLength(1)) && iterator<Key.Length; i++)   // KeyMatrix initialization with Key symbols
            {
                for (int j = 0; j < KeyMatrix.GetLength(1); j++)
                {
                    KeyMatrix[i,j] = Key[iterator];
                    iterator++;
                }
            }
        }
        public String Encrypt()
        {
            String EText = null;
            foreach (Char letter in Message)
            {
                bool letterFound = false;
                for (int i = 0; i < KeyMatrix.GetLength(1) && !letterFound; i++)   // KeyMatrix initialization with Key symbols
                {
                    for (int j = 0; j < KeyMatrix.GetLength(1) && !letterFound; j++)
                    {
                        if (letter == KeyMatrix[i, j])
                        {
                            EText += String.Format("{0:00}{1:00}", i, j);
                            letterFound = true;
                        }
                    }
                }
            }
            return EText;
        }
        public String Decrypt()
        {
            String PText = null;
            CHeckpoint
            // get EText string
            // get blocks of 4 digits

            return PText;
        }
    }
}
