#include "trithemius.h"

void Trithemius::keyParsing(string keyPath)
{
		ifstream keyI;
		keyI.open(keyPath);
		if (keyI.is_open() == false)
		{
				cout << "Unable to open key file\n";
				cin.get();
				exit(EXIT_FAILURE);
		}
		else
		{
				getline(keyI, keyType);
				if (keyType == "p")
				{
						//phrase key
						getline(keyI, KeyP);
				}
				else if (keyType == "c")
				{
						// coefficients key
						string current;
						int number = 0;
						while (true)
						{
								getline(keyI, current, ',');
								number = stoi(current);
								KeyC.push_back(number);
								if (keyI.eof())
								{
										keyI.close();
										break;
								}
						}
				}
		}
}

Trithemius::Trithemius(int argn, char** arguments)
{
		if (argn < 5)
		{
				cout << "Lack of arguments\n";
				cin.get();
				exit(EXIT_FAILURE);
		}
		regime = arguments[1];
		
		keyParsing(arguments[2]);		//get key as coef vector 
																//or string phrase

		alphabetType = arguments[3];
		if (alphabetType == "c")
		{
				activeAlphabet = alphabetCyrillic;
		}
		else if (alphabetType == "l")
		{
				activeAlphabet = alphabetLatin;
		}

		input = arguments[4];
		output = arguments[5];
		
		if (regime == "e")
		{
				Encrypt();
		}
		else if (regime == "d")
		{
				Decrypt();
		}
}

ifstream Trithemius::openfileI(string fileName)
{
		ifstream file;
		file.open(fileName, ios::in);
		if (file.is_open() == false)
		{
				cout << "Unable to open input file\n";
				cin.get();
				exit(EXIT_FAILURE);
		}
		return file;
}
ofstream Trithemius::openfileO(string fileName)
{
		ofstream file;
		file.open(fileName, ios::out);
		if (file.is_open() == false)
		{
				cout << "Unable to open output file\n";
				cin.get();
				exit(EXIT_FAILURE);
		}
		return file;
}
int Trithemius::keyCalculation(int position)
{
		int key = 0;
		for (int i = 0; i < KeyC.size(); i++)
		{
				key += KeyC[i] * pow(position, i);
		}
		return key;
}
void Trithemius::Encrypt()
{
		fileI = openfileI(input);
		fileO = openfileO(output);

		char c = 0;
		int position = 0;		//position in message
		if (keyType == "c")
		{
				for (;;)
				{
						c = fileI.get();
						key = keyCalculation(position);
						if (fileI.eof() == true)
								break;
						c = activeAlphabet.at((activeAlphabet.find(c) + key) % activeAlphabet.length());
						position++;
						fileO << c;
				}
		}
		else if (keyType == "p")
		{
				int j = 0; 
				for (;;)
				{
						c = fileI.get();
						if (fileI.eof() == true)
								break;
						j = position % KeyP.length();
						c = activeAlphabet.at((activeAlphabet.find(c) + j) % activeAlphabet.length());
						position++;
						fileO << c;
				}
		}
		fileO.close();
}
void Trithemius::Decrypt()
{
		fileI = openfileI(input);
		fileO = openfileO(output);
		int alphabetLength = activeAlphabet.length();
		char c = 0;
		int position = 0;		//position in message
		if (keyType == "c")
		{
				for (;;)
				{
						c = fileI.get();
						key = keyCalculation(position);
						if (fileI.eof() == true)
								break;
						c = activeAlphabet.at((activeAlphabet.find(c) - key % alphabetLength + alphabetLength) % alphabetLength);
						position++;
						fileO.put(c);
				}
		}
		else if (keyType == "p")
		{
				int j = 0;
				for (;;)
				{
						c = fileI.get();
						if (fileI.eof() == true)
								break;
						j = position % KeyP.length();
						c = activeAlphabet.at((activeAlphabet.find(c) - j) % activeAlphabet.length());
						position++;
						fileO << c;
				}
		}
		fileO.close();
}
Trithemius::~Trithemius()
{

}