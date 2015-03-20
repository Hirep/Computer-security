#pragma once
#include "../CryptoBase.h"
#include <string>
#include <iostream>
#include <fstream>

using namespace std;

class Xor : protected CryptoBase
{
		wifstream openfileI(string fileName);
		wofstream openfileO(string fileName);
		
		wifstream fileI;
		wofstream fileO;
		
		virtual void Encrypt();
		virtual void Decrypt();
public:
		Xor(int argn, char** arguments);
		~Xor();
};

