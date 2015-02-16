#pragma once
#include "../CryptoBase.h"
#include <string>
#include <iostream>
#include <fstream>

using namespace std;

class Caesar : protected CryptoBase
{
		const string alphabetCyrilic = "`1234567890-=~!@#$%^&*()_+[]\\;',./{}|:\"<>?éöóêåíãøùçõ¿ô³âàïğîëäæºÿ÷ñìèòüáş³ÉÖÓÊÅÍÃØÙÇÕ¯Ô²ÂÀÏĞÎËÄÆªß×ÑÌÈÒÜÁŞ,ÛÚ";
		const string alphabetLatin = "`1234567890-=~!@#$%^&*()_+qwertyuiop[]\\asdfghjkl;'zxcvbnm,./QWERTYUIOP{}|ASDFGHJKL:\"ZXCVBNM<>?,";
		string activeAlphabet;
		ifstream openfile(string fileName);
		
		ifstream fileI;
		ofstream fileO;

public:

		virtual void Encrypt();
		virtual void Decrypt();

		void BrootForce();

		Caesar(char** arguments);
		
		~Caesar();
};

