#include "xor.h"

Xor::Xor(int argn, char** arguments)
{
		if (argn < 4)
		{
				cout << "Lack of arguments\n";
				cin.get();
				exit(EXIT_FAILURE);
		}
		
		key = atoi(arguments[2]);
		key = key > 100 ? 100 : key;
		if (key < 0)
		{
				key *= -1;
		}
		input = arguments[4];
		output = arguments[5];

		if (regime == "e")
		{
				Encrypt();
		}
		else
		{
				Encrypt();
		}
}

wifstream Xor::openfileI(string fileName)
{
		wifstream file;
		file.open(fileName, ios_base::openmode(_IOSbinary));
		if (file.is_open() == false)
		{
				cout << "Unable to open input file\n";
				cin.get();
				exit(EXIT_FAILURE);
		}
		return file;
}
wofstream Xor::openfileO(string fileName)
{
		wofstream file;
		file.open(fileName, wios::out);
		if (file.is_open() == false)
		{
				cout << "Unable to open output file\n";
				cin.get();
				exit(EXIT_FAILURE);
		}
		return file;
}
void Xor::Encrypt()
{
		fileI = openfileI(input);
		fileO = openfileO(output);
		srand(key);
		wchar_t c;
		int counter = 0;
		for (;;)
		{
				c = fileI.get();
				if (fileI.eof() == true)
						break;
				int rando = rand()%255;
				fileO.put(c ^ rando);	
		}
		fileO.close();
}

void Xor::Decrypt()
{
		Encrypt();
}
Xor::~Xor()
{

}