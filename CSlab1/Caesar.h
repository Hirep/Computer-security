#pragma once
#include "../CryptoBase.h"
#include <string>
#include <iostream>
#include <fstream>

using namespace std;

class Caesar : protected CryptoBase
{
		const string alphabetCyrillic = " `1234567890-=~!@#$%^&*()_+[]\\;',./{}|:\"<>?������������������������������������������կԲ�������ƪ���������,�� ";
		const string alphabetLatin = " `1234567890-=~!@#$%^&*()_+qwertyuiop[]\\asdfghjkl;'zxcvbnm,./QWERTYUIOP{}|ASDFGHJKL:\"ZXCVBNM<>?,";
		string activeAlphabet;
		
		ifstream openfileI(string fileName);
		ofstream openfileO(string fileName);
		
		ifstream fileI;
		ofstream fileO;

		virtual void Encrypt();
		virtual void Decrypt();

		void BruteForce();

public:
		Caesar(int argn,char** arguments);
		~Caesar();
};

