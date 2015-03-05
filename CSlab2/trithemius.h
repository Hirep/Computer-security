#pragma once
#include "../CryptoBase.h"
#include <string>
#include <iostream>
#include <fstream>
#include <vector>

using namespace std;

class Trithemius : protected CryptoBase
{
		const string alphabetCyrillic = " `1234567890-=~!@#$%^&*()_+[]\\;',./{}|:\"<>?éöóêåíãøùçõ¿ô³âàïğîëäæºÿ÷ñìèòüáş³ÉÖÓÊÅÍÃØÙÇÕ¯Ô²ÂÀÏĞÎËÄÆªß×ÑÌÈÒÜÁŞ,ÛÚ ";
		const string alphabetLatin = " `1234567890-=~!@#$%^&*()_+qwertyuiop[]\\asdfghjkl;'zxcvbnm,./QWERTYUIOP{}|ASDFGHJKL:\"ZXCVBNM<>?,";
		string activeAlphabet;
		
		ifstream openfileI(string fileName);
		ofstream openfileO(string fileName);
		
		string keyType;

		vector<int>KeyC;	//holds coefficients
		string KeyP;	//holds secret phrase

		ifstream fileI;
		ofstream fileO;
		int keyCalculation(int);
		void keyParsing(string);

		virtual void Encrypt();
		virtual void Decrypt();

public:
		Trithemius(int argn, char** arguments);
		~Trithemius();
};

