#include "Caesar.h"

Caesar::Caesar(char** arguments)
{
		regime = arguments[1];
		key = atoi(arguments[2]);
		alphabetType = arguments[3];
		if (alphabetType == "c")
		{
				activeAlphabet = alphabetCyrilic;
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
						BrootForce();
				}
				else
				{
						Decrypt();
				}
		}
}

ifstream Caesar::openfile(string fileName)
{
		ifstream file;
		file.open(fileName, ios::in);
		if (file.is_open() == false)
		{
				cout << "Unable to open input file\n";
				exit(EXIT_FAILURE);
		}
		return file;
}

void Caesar::Encrypt()
{
		fileI = openfile(input);
		fileO.open(output, ios::out);

		if (!fileO.is_open())
		{
				cout << "Unable to open output file\n";
				exit(EXIT_FAILURE);
		}

		char c = 0;
		for (;;)
		{
				c = fileI.get();
				if (fileI.eof() == true)
						break;
				c = activeAlphabet.at((activeAlphabet.find(c) + key) % activeAlphabet.length());
				fileO.put(c);
		}
		fileO.close();
}
void Caesar::Decrypt()
{
		fileI = openfile(input);
		fileO.open(output, ios::out);

		if (!fileO.is_open())
		{
				cout << "Unable to open output file\n";
				exit(EXIT_FAILURE);
		}

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
void Caesar::BrootForce()
{

}
Caesar::~Caesar()
{

}