#pragma once
#include <string>
using namespace std;
class CryptoBase
{
protected:
		string regime; // defines whether to encrypt or to decrypt
		int key;		// key of crypto algorithm
		string alphabetType;
		string input;
		string output;		// files paths
public:

		virtual void Encrypt()= 0;
		virtual void Decrypt()= 0;
};

