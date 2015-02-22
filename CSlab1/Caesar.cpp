#include "Caesar.h"

Caesar::Caesar(int argn,char** arguments)
{
		if (argn < 5)
		{
				cout << "Lack of arguments\n";
				cin.get();
				exit(EXIT_FAILURE);
		}
		regime = arguments[1];

		key = atoi(arguments[2]);
		if (key < 0)
		{
				key *= -1;
		}

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
				if (key == 0)
				{
						BruteForce();
				}
				else
				{
						Decrypt();
				}
		}
}

ifstream Caesar::openfileI(string fileName)
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
ofstream Caesar::openfileO(string fileName)
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
void Caesar::Encrypt()
{
		fileI = openfileI(input);
		fileO = openfileO(output);

		char c = 0;
		for (;;)
		{
				c = fileI.get();
				if (fileI.eof() == true)
						break;
				c = activeAlphabet.at((activeAlphabet.find(c) + key) % activeAlphabet.length());
				fileO << c;
		}
		fileO.close();
}
void Caesar::Decrypt()
{
		fileI = openfileI(input);
		fileO = openfileO(output);

		char c = 0;
		int alphabetLength = activeAlphabet.length();
		for (;;)
		{
				c = fileI.get();
				if (fileI.eof() == true)
						break;
				c = activeAlphabet.at((activeAlphabet.find(c) - key % alphabetLength + alphabetLength) % alphabetLength);
				fileO.put(c);
		}
		fileO.close();
}
void Caesar::BruteForce()
{
		fileI = openfileI(input);
		fileO = openfileO(output);
		int alphabetLength = activeAlphabet.length();

		while (key < alphabetLength)
		{
				auto beginning = fileI.tellg();
				char c = 0;
				fileO << "Iteration #" << key << endl;
				for (;;)
				{
						c = fileI.get();
						if (fileI.eof() == true)
								break;
						c = activeAlphabet.at((activeAlphabet.find(c) - key % alphabetLength + alphabetLength) % alphabetLength);
						fileO.put(c);
				}
				fileO << endl;

				fileI.clear();
				fileI.seekg(0);
				
				key++;
		}

		fileO.close();
}
Caesar::~Caesar()
{

}